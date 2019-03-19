var query = '?id=1&name=jaron';

var matched = query.match(/(?!==)\w+/g);
var ans = {};
if (matched) {
  for (var i = 0; i < matched.length; i += 2) {
    ans[matched[i]] = matched[i + 1];
  }
}

console.log(ans);
