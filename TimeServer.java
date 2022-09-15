//cerner_2^5_2022
package cerner2to5;
public class TimeServer {
	public static void main(String[] args) throws Exception {
		java.net.ServerSocket timeServer = new java.net.ServerSocket(49152);
		int clients = Integer.MIN_VALUE;
		while (clients++ < Integer.MAX_VALUE) {
			java.net.Socket socket = timeServer.accept();
			new Thread(new Runnable() { public void run() {
				String zid=null;
				try {
					zid = new java.io.BufferedReader(new java.io.InputStreamReader(socket.getInputStream())).readLine();
					java.time.ZonedDateTime now = java.time.ZonedDateTime.now(java.time.ZoneId.of(java.time.ZoneId.getAvailableZoneIds().contains(zid)?zid:"Etc/GMT0"));
					new java.io.PrintWriter(socket.getOutputStream(), true).println("Current Date and Time: " + now.format(java.time.format.DateTimeFormatter.ofPattern("MM/dd/yyyy - HH:mm:ss")) + " at " + now.getZone().getDisplayName(java.time.format.TextStyle.FULL, java.util.Locale.getDefault()));
					socket.close();
				}catch(Exception ex) {
					System.out.println(zid==null?"null zone id":zid + " caused an error \n" + ex);
				}
			}
			}).start();
		}
		timeServer.close();
	}
}
