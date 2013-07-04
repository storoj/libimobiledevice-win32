#ifndef LIBCOMPAT_H
#define LIBCOMPAT_H

#include <crtdefs.h>

#if defined(_MSC_VER) || defined(_MSC_EXTENSIONS)
  #define DELTA_EPOCH_IN_MICROSECS  11644473600000000Ui64
#else
  #define DELTA_EPOCH_IN_MICROSECS  11644473600000000ULL
#endif
 
struct timezone
{
  int  tz_minuteswest; /* minutes W of Greenwich */
  int  tz_dsttime;     /* type of dst correction */
};

#ifndef snprintf
# define snprintf _snprintf
#endif

int gettimeofday(struct timeval *tv, struct timezone *tz);

#endif LIBCOMPAT_H
