$(function() {
  var $poetries = $("#poetries");

  function fetchPoetries(cb) {
    $.get("./poetries.json")
      .done(function(data, type, xhr) {
        cb && cb(data, xhr);
      })
      .fail(function(res) {
        console.log(res);
        $poetries.html("获取数据失败，可以打开控制台查询错误信息！");
      });
  }

  function reducePoetries(poetries) {
    return poetries.reduce(function(acc, cur, idx) {
      var key = new Date(cur.created_at).getFullYear();
      if (!acc[key]) acc[key] = [];
      acc[key].push({ data: cur, index: idx });
      return acc;
    }, {});
  }

  function renderHTML(year, poetries) {
    var s = "";
    $.each(poetries, function(index, item) {
      index = item.index;
      item = item.data;
      s += `
<p>
  <a
    class="poetry-link text-decoration--none"
    title="写于${item.created_at}"
    href="./poetry.html?key=${encodeURI(index)}"
  >${item.title}</a>
  <small class='badge--light'>${item.type === 1 ? "[旧体]" : ""}</small>
</p>`;
    });
    return `
<section>
  <p><small><b>${year}</b></small></p>
  <div>${s || "无"}</div>
</section>`;
  }

  function render($el, data) {
    data = reducePoetries(data);
    var s = "";
    for (var year in data) {
      if (!data.hasOwnProperty(year)) continue;
      s = renderHTML(year, data[year]) + s;
    }
    $el.html(s || "无");
  }

  window.setTimeout(function() {
    var data = JSON.parse(localStorage.getItem("poetries")) || [];
    render($poetries, data);
    fetchPoetries(function(data, xhr) {
      var lastModified = localStorage.getItem("last_modified");
      var nowLastModified = new Date(xhr.getResponseHeader("last-modified"))
        .getTime()
        .toString();
      console.log(lastModified, nowLastModified);
      if (!lastModified || lastModified != nowLastModified) {
        localStorage.setItem("last_modified", nowLastModified);
        localStorage.setItem("poetries", JSON.stringify(data));
        render($poetries, data);
      }
    });
  }, 500);
});
