//cerner_2tothe5th_2022
//cerner_2^5_2022
// Time client using Go
package main
import (
        "fmt"
        "net"
)
func main() {
        connection, err := net.Dial("tcp", "localhost:49152")
        if err != nil {
                panic(err)
        }
        _, err = connection.Write([]byte("Pacific/Tahiti\n"))
        buffer := make([]byte, 1024)
        mLen, err := connection.Read(buffer)
        if err != nil {
                fmt.Println("Error reading:", err.Error())
        }
        fmt.Println(string(buffer[:mLen]))
        defer connection.Close()
}
