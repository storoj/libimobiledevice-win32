/**
 * run app on iDevice using com.apple.debugserver - by <predrg@gmail.com>
 *
 * based on:
 *   ideviceinstaller - Copyright (C) 2010 Nikias Bassen <nikias@gmx.li>
 *   remote.c - from gdb
 *
 * Licensed under the GNU General Public License Version 2
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more profile.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 
 * USA
 */

/*
  build me with:
  $ gcc -g -pthread idevice-app-runner.c -o idevice-app-runner /usr/lib/libimobiledevice.so
*/

#include <signal.h>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <getopt.h>

#include <libimobiledevice/libimobiledevice.h>
#include <libimobiledevice/lockdown.h>

#ifdef WIN32
# include <windows.h>
# define sleep(x) Sleep(x*1000)
#endif

#ifdef WIN32
# define __strdup _strdup
#else
# define __strdup strdup
#endif

char *udid = NULL;
char *apppath = NULL;

int run_mode = 0;
static int quit_flag = 0;

/**
 * signal handler function for cleaning up properly
 */
static void clean_exit(int sig)
{
	fprintf(stderr, "Exiting...\n");
	quit_flag++;
}

static void print_usage(int argc, char **argv)
{
    char *name = NULL;

    name = strrchr(argv[0], '/');
    printf("Usage: %s OPTIONS\n", (name ? name + 1 : argv[0]));
    printf("Run (debug) apps on an iDevice.\n\n");
    printf
        ("  -U, --udid UDID\tTarget specific device by its 40-digit device UDID.\n"
         "  -r, --run PATH\tRun (debug) app specified by on-device path (use ideviceinstaller -l -o xml to find it).\n"
         "  -h, --help\t\tprints usage information\n"
         "  -d, --debug\t\tenable communication debugging\n" "\n");
}

static void parse_opts(int argc, char **argv)
{
    static struct option longopts[] = {
        {"help", 0, NULL, 'h'},
        {"udid", 1, NULL, 'U'},
        {"run", 1, NULL, 'r'},
        {"debug", 0, NULL, 'd'},
        {NULL, 0, NULL, 0}
    };
    int c;

    while (1) {
        c = getopt_long(argc, argv, "hU:r:d", longopts,
                        (int *) 0);
        if (c == -1) {
            break;
        }

        switch (c) {
        case 'h':
            print_usage(argc, argv);
            exit(0);
        case 'U':
            if (strlen(optarg) != 40) {
                printf("%s: invalid UDID specified (length != 40)\n",
                       argv[0]);
                print_usage(argc, argv);
                exit(2);
            }
            udid = __strdup(optarg);
            break;
        case 'r':
            run_mode = 1;
            apppath = __strdup(optarg);
            break;
        case 'd':
            idevice_set_debug_level(1);
            break;
        default:
			run_mode = 1;
			break;
            //print_usage(argc, argv);
            //exit(2);
        }
    }

    //if (optind <= 1 || (argc - optind > 0)) {
    //    print_usage(argc, argv);
    //    exit(2);
    //}
}

#define WITH_DEBUG

char tohex(int x)
{
    static char* hexchars = "0123456789ABCDEF";
    return hexchars[x];
}

unsigned int fromhex(char c)
{
    if (c >= '0' && c <= '9')
        return c - '0';
    else if (c >= 'a' && c <= 'f')
        return 10 + c - 'a';
    else if (c >= 'A' && c <= 'F')
        return 10 + c - 'A';
}

void send_str(char* buf, idevice_connection_t connection)
{
    int bytes = 0;
    idevice_connection_send(connection, buf, strlen(buf), (uint32_t*)&bytes);
#ifdef WITH_DEBUG
    printf("send: bytes=%d (%s)\n", bytes, buf);
#endif
}

void recv_pkt(idevice_connection_t connection, char **received_data, int *received_data_length)
{
    int bytes = 0;
    char buf[16*1024];
    idevice_connection_receive_timeout(connection, buf, sizeof(buf)-1, (uint32_t*)&bytes, 100);
#ifdef WITH_DEBUG
    printf("recv: bytes=%d\n", bytes);
#endif
    if (bytes >= 0)
        buf[bytes] = 0x00;
#ifdef WITH_DEBUG
    printf("d='%s'\n", buf);
#endif
    if (bytes > 0 && buf[0] == '$') {
        send_str("+", connection);
        if (bytes > 1 && buf[1] == 'O') {
            char* c = buf+2;
            char* bufend = buf+strlen(buf);
            char buf3[16*1024];
            int i = 0;
            while (*c != '#' && c < bufend)
                buf3[i++] = fromhex(*c++) << 4 | fromhex(*c++);
            buf3[i] = 0x00;
#ifdef WITH_DEBUG
            printf("recv: data='%s'\n", buf3);
#else
            printf("%s", buf3);
#endif
            fflush(stderr);
            fflush(stdout);
        }
    }
	if (received_data_length) {
		*received_data_length = bytes;
	}
	if (received_data) {
		*received_data = strdup(buf);
	}
}

void recv_pkt(idevice_connection_t connection)
{
	recv_pkt(connection, NULL, NULL);
}

void send_pkt(char* buf, idevice_connection_t connection)
{
    int i;
    unsigned char csum = 0;
    char *buf2 = (char *)malloc (32*1024);
    int cnt = strlen (buf);
    char *p;

    /* Copy the packet into buffer BUF2, encapsulating it
       and giving it a checksum.  */

    p = buf2;
    *p++ = '$';

    for (i = 0; i < cnt; i++)
    {
        csum += buf[i];
        *p++ = buf[i];
    }
    *p++ = '#';
    *p++ = tohex ((csum >> 4) & 0xf);
    *p++ = tohex (csum & 0xf);

    *p = '\0';

    int bytes = 0;
    idevice_connection_send(connection, buf2, strlen(buf2), (uint32_t*)&bytes);
#ifdef WITH_DEBUG
    printf("send: bytes=%d (%s)\n", bytes, buf);
#endif
    free(buf2);
}

int main(int argc, char **argv)
{
    idevice_t phone = NULL;
    lockdownd_client_t client = NULL;
    idevice_connection_t connection = NULL;
    int res = 0;

	signal(SIGINT, clean_exit);
	signal(SIGTERM, clean_exit);
#ifndef WIN32
	signal(SIGQUIT, clean_exit);
	signal(SIGPIPE, SIG_IGN);
#endif

    parse_opts(argc, argv);

    argc -= optind;
    argv += optind;

    if (IDEVICE_E_SUCCESS != idevice_new(&phone, udid)) {
        fprintf(stderr, "No iPhone found, is it plugged in?\n");
        return -1;
    }

    if (LOCKDOWN_E_SUCCESS != lockdownd_client_new_with_handshake(phone, &client, "idevice-app-runner")) {
        fprintf(stderr, "Could not connect to lockdownd. Exiting.\n");
        goto leave_cleanup;
    }

    lockdownd_service_descriptor_t service_descriptor = NULL;
    if ((lockdownd_start_service
         (client, "com.apple.debugserver",
          &service_descriptor) != LOCKDOWN_E_SUCCESS) || !service_descriptor->port) {
        fprintf(stderr,
                "Could not start com.apple.debugserver!\n");
        goto leave_cleanup;
    }

    if (idevice_connect(phone, service_descriptor->port, &connection) != IDEVICE_E_SUCCESS) {
        fprintf(stderr, "idevice_connect failed!\n");
        goto leave_cleanup;
    }

    if (client) {
        /* not needed anymore */
        lockdownd_client_free(client);
        client = NULL;
    }

    /* send_str("+", connection); */

	char *response;
	int response_length;
	char cmd[2000];
	FILE *cmds_file = fopen("idevice-debug-client-cmds.txt", "r");
	if (!cmds_file) {
		printf("no cmds file idevice-debug-client-cmds.txt\n");
		return 1;
	}
	while (!feof(cmds_file) && !quit_flag) {

		if (!fgets(cmd, 2000, cmds_file)) {
			break;
		}

		if (cmd[strlen(cmd)-1] == '\n') {
			cmd[strlen(cmd)-1] = 0x00;
		}
        printf("'%s'\n", cmd);
        //sleep(1);
        send_pkt(cmd, connection);
		recv_pkt(connection, &response, &response_length);
	}
	fclose(cmds_file);

	while (!quit_flag) {
		do {
			recv_pkt(connection, &response, &response_length);
		} while (response_length == 0);

		printf("cmd: ");
		gets(cmd);
		if (strlen(cmd)) {
			send_pkt(cmd, connection);
			recv_pkt(connection, &response, &response_length);
		}
	}

    /* kill */
    send_pkt("k", connection);

leave_cleanup:
    if (connection) {
        idevice_disconnect(connection);
    }

    if (client) {
        lockdownd_client_free(client);
    }
    idevice_free(phone);

    if (udid) {
        free(udid);
    }
    if (apppath) {
        free(apppath);
    }

    return res;
}