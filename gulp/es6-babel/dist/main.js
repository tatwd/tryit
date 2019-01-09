"use strict";

var _Pen = _interopRequireDefault(require("./Pen"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var str = 'Hello World!';
var pen = new _Pen.default(str);
pen.logger();