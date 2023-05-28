#include <stdio.h>
#include <string.h>

#include "bsp/board.h"
#include "tusb.h"

#include "xbox/xbox.hpp"

int main()
{
    using namespace NandyFlasher;

    tusb_init();

    g_xbox.Init();

    int runtime = 0;
    while (1)
    {
        tud_task();
        printf("Runtime: %d\n", runtime++);
    }
}