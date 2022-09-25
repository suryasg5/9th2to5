// cerner_2tothe5th_2022
// cerner_2^5_2022
use std::io::prelude::*;
use std::net::TcpStream;
fn main() -> std::io::Result<()> {
    let mut stream = TcpStream::connect("127.0.0.1:49152")?;

    stream.write(b"Australia/Broken_Hill\n")?;
	let mut buf = [0;512];
	stream.read(&mut buf)?;
	println!("{}",String::from_utf8_lossy(&buf));
    Ok(())
}
