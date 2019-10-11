// Random a obj from `arr` by the `key`
function random_by(arr, key = 'rate') {
  var sumRate = arr.reduce((ret,cur) => ret += cur[key], 0);
  var numRate = Math.random() * sumRate;
  var sum = 0;
  for (var obj of arr) {
    sum += obj[key];
    if (sum > numRate) return obj;
  }
}

// test data
var arr = [
  { id: 1, rate: 16 },
  { id: 2, rate: 20 },
  { id: 3, rate: 3 },
  { id: 4, rate: 7 },
];

// 理想的概率
var sumRate = arr.reduce((ret,cur) => ret += cur.rate, 0);
for (var obj of arr) {
  console.log('#'+obj.id, obj.rate/sumRate);
}

// 实际的概率
var total = 5000;
var couter = {};
for (var i = 0; i < total; i++) {
  var obj = random_by(arr);
  if (!couter[obj.id]) couter[obj.id] = 1;
  else couter[obj.id] += 1;
}
for (var k in couter) {
  if (couter.hasOwnProperty(k)) {
    console.log('>'+k, couter[k]/total);
  }
}
