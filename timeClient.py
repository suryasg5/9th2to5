#cerner_2tothe5th_2022
#cerner_2^5_2022
import socket
soc = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
soc.connect(("localhost",49152))
soc.send("Pacific/Honolulu\n".encode())
data = soc.recv(1024)
print(data.decode())
soc.close()
