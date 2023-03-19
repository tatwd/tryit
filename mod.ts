const destWebsite = "https://blog.cloong.me"

// function handleRequest(request) {
//   const { pathname } = new URL(request.url);

//   return new Response(
//     `<body
//       align="center"
//       style="font-family: Avenir, Helvetica, Arial, sans-serif; font-size: 1.5rem;"
//     >
//       <p>pathname: ${pathname}</p>
//     </body>`,
//     {
//       headers: {
//         "content-type": "text/html; charset=UTF-8",
//       },
//     },
//   );
// }

function handleRequest(request) {
  const { pathname } = new URL(request.url);
  return new Response(
    `<head>
      <meta http-equiv="Refresh" content="0; URL=${destWebsite}${pathname}" />
    </head>`,
    {
      headers: {
        "content-type": "text/html; charset=UTF-8",
      },
    },
  );

}


addEventListener("fetch", (event) => {
  event.respondWith(handleRequest(event.request));
});
