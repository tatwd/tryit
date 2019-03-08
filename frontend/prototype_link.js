// Class A
function A() {
  this.foo = 'A';
}

A.prototype.name = 'jaron';

/*
此时 A.prototype 默认为:
  {
    // 自定义属性
    name: 'jaron',

    // 固定属性
    constructor: function A(){},
    __proto__: Object.prototype
  }

A.prototype 上的属性要通过 __proto__ 访问：
  a.__proto__.name
但通过 a.name 访问时，如果 a 的本地属性（如 foo）不包含 name，
会到 a.__proto__ 寻找该属性

prototype 是类的构造函数特有的属性，代表原型对象
__proto__ 是实例对象的属性，指向类的原型对象
  obj.__proto__ === obj_constructor.prototype
  obj.__proto__.constructor == obj_constructor
*/

var a = new A();
/*
a 的结构：
  {
    foo: 'A',
    __proto__: A.prototype
  }
*/

a.name = 'leo';
console.log(a.name === a.__proto__.name); // true
console.log(A.prototype instanceof Object); // true
console.log(a.constructor === A); // true
console.log(a.__proto__ === A.prototype); // true
console.log(A.prototype.__proto__ === Object.prototype); // true

/*
原型链：
    __proto__                 __proto__                        __proto__
  a -------------> A.prototype -------------> Object.prototype -------------> null

即：
  {
    foo: 'A',
    __proto__: {
      name: 'jaron',
      constructor: function A(){...},
      __proto__: {
        constructor: function Object(){...},
        __proto__: null
      }
    }
  }

注意：
  A 也是一个函数对象

*/
console.log(A instanceof Function); // true
console.log(A.__proto__.constructor);

// Class B
function B() {
  this.bar = 'B';
}
B.prototype = a; // 从 a 继承

a.foo = 'a';
a.name = 'jack';

var b = new B();
console.log('a.__proto__.name:', a.__proto__.name)
console.log('b:', b.foo, b.name);

// foo, name 修改的不是继承而来的属性
// 两者将成为 b 的本地属性
b.foo = 'b';
b.name = 'tom';
console.log('a:', a.foo, a.name);
console.log('b.__proto__:', b.__proto__.foo, b.__proto__.name);
console.log('b.__proto__.__proto__.name:', b.__proto__.__proto__.name)

// 通过 __proto__ 修改原型对象的属性
b.__proto__.foo = 'b_foo';
console.log('a.foo:', a.foo)
console.log('b.foo:', b.foo)

/*
a 和 b 继承关系（当 B.prototype = a）：
  {
    bar: 'B',
    __proto__: {
      foo: 'A',
      __proto__: {
        name: 'jaron',
        constructor: function A(){...},
        __proto__: {
          constructor: function Object(){...},
          __proto__: null
        }
      }
    }
  }
*/
