const response = await fetch("http://localhost:5077/stream");
const textDecoder = new TextDecoder();

for await (const chunk of response.body) {
  console.log(textDecoder.decode(chunk));
}
