using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMWEBUSBLib;

namespace WM500V5Lib
{
    public class UsbCom
    {
        private IWwusb usbPort;

        public async Task<object> Invoke(dynamic input)
        {
            // read call parameters
            string cmd = (string)input.command;
            string value = (string)input.value;

            // create the object that manages USB comm.
            usbPort = new Wwusb();
            // process commands
            switch (cmd)
            {
                case "ReadTerminalNumber":
                    return await ReadTerminalNumber();
                    break;
                case "GetRecords":
                    return await GetRecords();
                    break;
                case "DeleteRecords":
                    return await DeleteRecords();
                    break;
                case "SetDateTime":
                    return await SetDateTime();
                    break;
                default:
                    return String.Format("ERROR: Unknow command [{0}]", cmd);
                    break;
            }
            
        }

        public async Task<string> ReadTerminalNumber()
        {
                // it controls if usb is opened
                if (usbPort.OpenUsb(2002) >= 0)
                {
                    string termNo = usbPort.GetTermno();
                    usbPort.CloseUsb();
                    return termNo;
                }
                else
                {
                    return "ERROR: Can't open USB port";
                }

        }

        public async Task<string> GetRecords()
        {
            // it controls if usb is opened
            if (usbPort.OpenUsb(2002) >= 0)
            {
                usbPort.SetModel(2, 1);
                string records = usbPort.GetRecords();
                usbPort.CloseUsb();
                return records;
            }
            else
            {
                return "ERROR: Can't open USB port";
            }

        }

      
        public async Task<string> SetTermNo(string termNo)
        {
            // it controls if usb is opened
            if (usbPort.OpenUsb(2002) >= 0)
            {
                string message = "--";
                usbPort.SetModel(2, 1);
                long result = usbPort.SetTermno(termNo);
                if (result >= 0)
                    message = "OK";
                else
                    message = String.Format("ERROR: Can't set terminal number [{0}]", result);
                usbPort.CloseUsb();
                return message;
            }
            else
            {
                return "ERROR: Can't open USB port";
            }
        }

        public async Task<string> SetDateTime()
        {
            // it controls if usb is opened
            if (usbPort.OpenUsb(2002) >= 0)
            {
                string message = "--";
                usbPort.SetModel(2, 1);
                DateTime dt = DateTime.Now;
                long result = usbPort.SetDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
                if (result >= 0)
                    message = "OK";
                else
                    message = String.Format("ERROR: Can't set terminal number [{0}]", result);
                usbPort.CloseUsb();
                return message;
            }
            else
            {
                return "ERROR: Can't open USB port";
            }
        }

        public async Task<string> DeleteRecords()
        {
            // it controls if usb is opened
            if (usbPort.OpenUsb(2002) >= 0)
            {
                string message = "--";
                usbPort.SetModel(2, 1);
                long result = usbPort.ErasureRecords();
                if (result >= 0)
                    message = "OK";
                else
                    message = String.Format("ERROR: Can't delete records [{0}]", result);
                usbPort.CloseUsb();
                return message;
            }
            else
            {
                return "ERROR: Can't open USB port";
            }
        }

    }
}
