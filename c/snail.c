#include <stdio.h>
#include <stdlib.h>

// UP is 1, DOWN is 2, LEFT is 3, RIGHT is 4

int *snail(size_t *outsz, const int **mx, size_t m, size_t n) {

int cur[2] = {0, -1}, top_lim = 0, bottom_lim = (int) n -1, left_lim = 0, right_lim = (int) m -1, direction = 4, count = m*n, rb = malloc (sizeof (int) * count), *p = rb;
*outsz = m*n;

while (count) { 
  switch (direction) {
    case 4:
      if (cur[1] == right_lim) {
        direction = 2;
        top_lim++;
        break;
        }
      *p++ = (int) mx[cur[0]][++cur[1]];
      count--;
      break;
    case 2:
      if (cur[0] == bottom_lim) {
        direction = 3;
        right_lim--;
        break;
        }
      *p++ = (int) mx[++cur[0]][cur[1]];      
      count--;
      break;
    case 3:
      if (cur[1] == left_lim) {
        direction = 1;
        bottom_lim--;
        break;
        }
      *p++ = (int) mx[cur[0]][--cur[1]];      
      count--;
      break;
    case 1:
      if (cur[0] == top_lim) {
        direction = 4;
        left_lim++;
        break;
        }
      *p++ = (int) mx[--cur[0]][cur[1]];      
      count--;
      break;
    }
  }  
return (rb);
}