#include "common.hpp"

void tud_mount_cb(void)
{
}

void tud_umount_cb(void)
{
}

void tud_suspend_cb(bool remote_wakeup_en)
{
    (void)remote_wakeup_en;
}

void tud_resume_cb(void)
{
}

void tud_cdc_rx_cb(uint8_t itf)
{
    (void)itf;

    uint32_t Version = 1;

    uint32_t avilable_data = tud_cdc_available();

    uint32_t needed_data = sizeof(struct NandyFlasher::Command);
    {
        uint8_t cmd;
        tud_cdc_peek(&cmd);
    }

    if (avilable_data >= needed_data)
    {
        struct NandyFlasher::Command cmd;
        uint32_t received = tud_cdc_read(&cmd, sizeof(cmd));

        if (received != sizeof(cmd))
            return;

        NandyFlasher::g_commands.Update(cmd);

        // if (cmd.command == 0x00)
        // {
        //     tud_cdc_write(&Version, sizeof(Version));
        //     tud_cdc_write_flush();
        //     avilable_data = tud_cdc_available(); // check if there is more data available
        // }
    }
}

void tud_cdc_tx_complete_cb(uint8_t itf)
{
    (void)itf;
}

int main()
{

    NandyFlasher::g_core.Initialize();
    NandyFlasher::g_commands.Initialize();
    NandyFlasher::g_xbox.Initialize();

    while (1)
    {
        NandyFlasher::g_core.Update();
    }
}