package main

import (
	"bufio"
	"fmt"

	// "github.com/hedhyw/Go-Serial-Detector/pkg/v1/serialdet"
	"github.com/tarm/serial"
)

// func ComPortNames(VID string, PID string) []string {
// 	regex := regexp.MustCompile(fmt.Sprintf("^VID_%s.PID_%s", VID, PID))
// 	var stringList []string
// 	registryKey1, err := registry.OpenKey(registry.LOCAL_MACHINE, "SYSTEM\\CurrentControlSet\\Enum", registry.QUERY_VALUE|registry.ENUMERATE_SUB_KEYS)
// 	if err != nil {
// 			fmt.Println("Error opening registry key: ", err)
// 			return nil
// 	}

// 	defer registryKey1.Close()

// 	keyNames, err := registryKey1.ReadSubKeyNames(-1)
// 	if err != nil {
// 			fmt.Println("Error reading subkey names: ", err)
// 			return nil
// 	}

// 	for _, keyName := range keyNames {
// 			if regex.MatchString(keyName) {
// 					registryKey2, err := registry.OpenKey(registry.LOCAL_MACHINE, fmt.Sprintf("SYSTEM\\CurrentControlSet\\Enum\\%s", keyName), registry.QUERY_VALUE|registry.ENUMERATE_SUB_KEYS)
// 					if err != nil {
// 							fmt.Println("Error opening registry key: ", err)
// 							return nil
// 					}

// 					defer registryKey2.Close()

// 					keyNames, err := registryKey2.ReadSubKeyNames(-1)
// 					if err != nil {
// 							fmt.Println("Error reading subkey names: ", err)
// 							return nil
// 					}

// 					for _, keyName := range keyNames {
// 							if contains(stringList, keyName) {
// 									continue
// 							}

// 							registryKey3, err := registry.OpenKey(registry.LOCAL_MACHINE, fmt.Sprintf("SYSTEM\\CurrentControlSet\\Enum\\%s\\%s", keyName, keyName), registry.QUERY_VALUE)
// 							if err != nil {
// 									fmt.Println("Error opening registry key: ", err)
// 									return nil
// 							}

// 							defer registryKey3.Close()

// 							portName, _, err := registryKey3.GetStringValue("PortName")
// 							if err != nil {
// 									fmt.Println("Error reading port name: ", err)
// 									return nil
// 							}

// 							stringList = append(stringList, portName)
// 					}
// 			}
// 	}
// 	return stringList
// }

// func SerialPortNames() []string {
// 	var names []string
// 	for i := 0; i < 256; i++ {
// 			name := fmt.Sprintf("COM%d", i+1)
// 			names = append(names, name)
// 	}
// 	return names
// }

// func contains(slice []string, str string) bool {
// 	for _, s := range slice {
// 			if s == str {
// 					return true
// 			}
// 	}
// 	return false
// }

// func OpenSerial() *serial.Port {
// 	s := &serial.Config{Name: "", Baud: 115200}
// 	serialPort, err := serial.OpenPort(s)
// 	if err != nil {
// 			fmt.Println("Error opening serial port: ", err)
// 			return nil
// 	}
// 	defer serialPort.Close()
// 	stringList := ComPortNames("600D", "7001")
// 	if len(stringList) <= 0 {
// 			fmt.Println("Can't find PicoFlasher COM port\n\nUpdate the PicoFlasher firmware and check your drivers")
// 			return nil
// 	}
// 	return serialPort
// }

func main() {
	config := &serial.Config{
		Name: "COM5",
		Baud: 9600,
		ReadTimeout: 1,
		Size: 8,
	}

	stream, err := serial.OpenPort(config)
  if err != nil {
    fmt.Println("Error opening serial port: ", err)
  }

	scanner := bufio.NewScanner(stream)
  for scanner.Scan() {
    fmt.Println(scanner.Text())
  }
  if err := scanner.Err(); err != nil {
    fmt.Println("Error reading from serial port: ", err)
  }
}