const ajax = function (url, settings) {

    // set default values
    ({
        method = 'GET',
        responseType = '', // x-www-form-urlencoded
        header = {},
        timeout = 0,
        data = null,
        async = true
    } = settings || {});

    // get XMLHttpRequest object
    let getXhr = () => {
        return new XMLHttpRequest() || new ActiveXObject("Microsoft.XMLHTTP");
    };

    return new Promise((resolve, reject) => {
        const xhr = getXhr();
        
        xhr.open(method, url, async);

        xhr.onreadystatechange = function () {
            if (this.readyState !== 4) return;

            this.status === 200
                ? resolve({
                    _data: this.response,
                    getJson: function () {
                        let __data = typeof this._data === 'object'
                            ? this._data
                            : JSON.parse(this._data);
                        
                        return __data === null
                            ? __data
                            : (
                                __data.d && __data.d !== ''
                                ? JSON.parse(__data.d)
                                : __data
                            );
                    },
                    getText: function () {
                        return this._data;
                    }
                })
                : reject(new Error(this.statusText));
        }

        xhr.timeout = timeout;
        xhr.responseType = responseType;

        // set request header
        for (let item in header) {
            xhr.setRequestHeader(item, `application/${header[item]}`);
        }

        xhr.send(data);
    });
};

const dataContainer = document.querySelector('.data-container');

let url = {
    test: 'test.json',
    aspx: '../Demo.aspx/ServerMethod'
};

let settings = {
    get: {
        method: 'GET',
        // responseType: 'json',
        header: {
            'content-type': 'json'
        }
    },
    post: {
        method: 'POST',
        responseType: 'json',
        header: {
            'content-type': 'json'
        },
        data: JSON.stringify({
            id: 1
        })
    }
}
// ajax(url.test, settings.get)
ajax(url.aspx, settings.post)
    .then(response => response.getJson())
    .then(data => {
        dataContainer.innerHTML = JSON.stringify(data);
    })
    .catch(error => {
        dataContainer.innerHTML = error;
    });