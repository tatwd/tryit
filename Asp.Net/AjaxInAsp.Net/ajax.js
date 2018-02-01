const ajax = function (
    url,
    settings = {
        method: "GET",
        contentType: "x-www-form-urlencoded",
        data: null
    }) {

    let getXhr = () => {
        return new XMLHttpRequest();
    };

    return new Promise((resolve, reject) => {
        const xhr = getXhr();

        xhr.open(settings.method, url);

        xhr.onreadystatechange = function () {
            if (this.readyState !== 4) {
                return;
            }

            this.status === 200
                ? resolve(this.response)
                : reject(new Error(this.statusText));
        }

        xhr.responseType = settings.contentType;
        xhr.setRequestHeader("Content-Type", `application/${settings.contentType}`);

        settings.data
            ? xhr.send(JSON.stringify(settings.data))
            : xhr.send();
    });
};

const dataContainer = document.querySelector('.data-container');

ajax("../Demo.aspx/ServerMethod", {
    method: "POST",
    contentType: "json",
    data: {
        id: 1
    }
})
    .then(data => {
        //console.log(data)
        dataContainer.innerHTML = JSON.stringify(data);
    }).catch(error => {
        dataContainer.innerHTML = error;
    });

//const getJSON = function (url) {
//    const promise = new Promise(function (resolve, reject) {
//        const handler = function () {
//            if (this.readyState !== 4) {
//                return;
//            }
//            if (this.status === 200) {
//                resolve(this.response);
//            } else {
//                reject(new Error(this.statusText));
//            }
//        };
//        const client = new XMLHttpRequest();
//        client.open("GET", url);
//        client.onreadystatechange = handler;
//        client.responseType = "json";
//        client.setRequestHeader("Accept", "application/json");
//        client.send();

//    });

//    return promise;
//};

//getJSON("/posts.json").then(function (json) {
//    console.log('Contents: ' + json);
//}, function (error) {
//    console.error('出错了', error);
//});