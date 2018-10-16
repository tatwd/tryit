var input = document.querySelector('.input-text');
var subBtn = document.querySelector('.sub-btn');


var dogo = (function () {


    // Dogo class
    var Dogo = function (selectorOrdom) {
        this.element = selectorOrdom || {};
        this.data = [];
    };

    // get dom element(s) form html
    Dogo.prototype.dom = function (selector) {
        var that = this;
        var dom = typeof selector === 'string'
            ? (
                selector.startsWith("#")
                    ? document.querySelector(selector)
                    : document.querySelectorAll(selector)
            )
            : null;

        var Getter = function (_dom) {
            this.dom = _dom;
        };

        Getter.prototype.at = function (number) {
            var ele
                = typeof number === 'undefined' || (number < 0 || number >= this.dom.length)
                ? null
                : this.dom[number];

            // that.element = ele;

            // ele.prototype.render = that.render;

            return ele; // dogo object
        };

        Getter.prototype.all = function () {
            return this.dom;
        };

        return new Getter(dom);
    };

    // judge dom element method
    Dogo.prototype.isDom = function (obj) {
        return typeof HTMLElement === 'object' // the type of `HTMLElement` in Chrome is a function
            ? (obj instanceof HTMLElement)
            : (typeof obj === 'object' && obj.nodeType === 1 && typeof obj.nodeName === 'string');
    };

    // ajax method
    Dogo.prototype.ajax = function (setting) {
        var that = this;

        var Ajax = function (setting) {
            this.xhr = new XMLHttpRequest();
            this.setting = setting || {};
        };

        Ajax.prototype.get = function () {

            this.xhr.open("GET", this.setting.url);
            return that;
        };

        Ajax.prototype.post = function () {
            this.xhr.open("POST", this.setting.url);
            this.xhr.setRequestHeader("Content-Type", `application/${this.setting.contentType}`); // json type
            this.xhr.send(JSON.stringify(this.setting.data));

            return this;
        };

        Ajax.prototype.render = function (setting) {

            this.xhr.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {

                    var jsonStr = this.responseText;
                    var jsonObj = {};

                    if (jsonStr) {
                        var _data = JSON.parse(jsonStr).d;
                        jsonObj = _data ? JSON.parse(_data) : null;
                    }

                    jsonObj && that.data.push(jsonObj);

                    // var index = setting.tmp.indexOf('{');

                    var element = that.dom(setting.ele).all();
                    var template = document.createElement('template');

                    if (that.data.length == 0) {
                        element.innerHTML = "NULL";
                        return;
                    }

                    setting.tmp = setting.tmp.replace(/{{.*}}/, that.data[0].Name);
                    template.innerHTML = setting.tmp;
                    
                    var clone = document.importNode(template.content, true);
                    // element.appendChild(clone);
                    element.innerHTML = clone.textContent || "NULL";

                    that.data = [];
                }
            };
        };

        return new Ajax(setting);
    };

    return new Dogo();
})();

var $ = dogo;

subBtn.onclick = function () {
    var text = input.value;

    $.ajax({
        url: "./DemoA.aspx/ServerMethod",
        contentType: 'json;charset=utf-8',
        data: {
            id: Number(input.value)
        }
    }).post().render({
        ele: '#app',
        tmp: `<p>The message from server is, "Hello, I am {{ Name }}."</p>`
    });
};

// ------------

//!(function AppStart() {

//    var template = {};
//    var clone = {};
//    var render = {};
//    var app = document.querySelector('#app');

//    if (!dogo.isDomObj(app)) {
//        console.log(`${app} is not a html element object!`);
//        return;
//    }

//    // add `tmp` content to `ele`
//    render = {
//        ele: app,
//        tmp: `<p>this is the content of template.</p>`
//    };

//    temp = document.createElement('template');
//    temp.innerHTML = render.tmp;
//    clone = document.importNode(temp.content, true);

//    render.ele.appendChild(clone);

//})();

//function sendXhr(data) {
//    var xhr = new XMLHttpRequest();

//    //xhr.open("POST", "DemoA.aspx", true);
//    //xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

//    xhr.open("POST", "./DemoA.aspx/ServerMethod", true);
//    xhr.setRequestHeader("Content-Type", "application/json;charset=utf-8"); // json type
//    //xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

//    var dataJsonObj = {
//        "id": data
//    };

//    // xhr.send("{'id': 12}");
//    xhr.send(JSON.stringify(dataJsonObj)); // 给 WebMethod 方法传递参数
//    // xhr.send("id=" + text);

//    xhr.onreadystatechange = function () {
//        if (xhr.readyState == 4 && xhr.status == 200) {

//            var jsonStr = xhr.responseText;
//            var jsonObj = [];
//            var responseTextDom = document.querySelector("#response-text");

//            if (jsonStr) {
//                jsonObj = JSON.parse(jsonStr);

//                // console.log("jsonObj:", jsonObj);

//                responseTextDom.innerHTML = jsonObj.d; // jsonStr;
//            } else {
//                //console.log("There is no the student!");

//                responseTextDom.innerHTML = "There is no the student!";
//            }

//            // responseTextDom.innerHTML = jsonObj.Name;
//            // console.log(xhr.responseText);
//        }
//    };
//}

//subBtn.onclick = function () {
//    var text = input.value;

//    sendXhr(text);
//};