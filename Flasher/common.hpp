// Libs
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

// Custom Libs
#include "bsp/board.h"
#include "hardware/vreg.h"
#include "hardware/clocks.h"
#include "pico/stdlib.h"
#include "pico/bootrom.h"
#include "tusb.h"

#include "core/core.hpp"
#include "commands/commands.hpp"
#include "xbox/xbox.hpp"

#define ONBOARD_LED_PIN 25

#define GP0_PIN 1
#define GP1_PIN 2
#define GP_GROUND0_PIN 3
#define GP2_PIN 4
#define GP3_PIN 5
#define GP4_PIN 6
#define GP5_PIN 7
#define GP_GROUND1_PIN 8
#define GP6_PIN 9
#define GP7_PIN 10
#define GP8_PIN 11
#define GP9_PIN 12
#define GP_GROUND2_PIN 13
#define GP10_PIN 14
#define GP11_PIN 15
#define GP12_PIN 16
#define GP13_PIN 17
#define GP_GROUND3_PIN 18
#define GP14_PIN 19
#define GP15_PIN 20
#define GP16_PIN 21
#define GP17_PIN 22
#define GP_GROUND4_PIN 23
#define GP18_PIN 24
#define GP19_PIN 25
#define GP20_PIN 26
#define GP21_PIN 27
#define GP_GROUND5_PIN 28
#define GP22_PIN 29
#define GP_RUN_PIN 30
#define GP26_PIN 31
#define GP27_PIN 32
#define GP_ADC_GND_PIN 33
#define GP28_PIN 34
#define GP_ADC_VREF_PIN 35
#define GP_3V3_OUT_PIN 36
#define GP_3V3_EN_PIN 37
#define GP_GROUND6_PIN 38
#define GP_VSYS_PIN 39
#define GP_VBUS_PIN 40
