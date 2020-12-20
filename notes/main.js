$(function () {
  var books = $("#books");
  var badges = {
    // TODO: "badge-secondary",
    READING: "badge-info",
    FINISHED: "badge-success",
  };
  var authorTypes = {
    WRITER: "作者",
    WRITER_ZHU: "注解",
    WRITER_PD: "评点",
    TRANSLATOR: "译者",
    EDITOR: "编者",
    EDITOR_JD: "校点",
    EDITOR_JJ: "集解",
  };
  var bookType = {
    0: "电子书",
    1: "纸质书",
  };

  function loading(isLoading) {
    var html = isLoading
      ? `
<div class="text-center loading">
  <div class="spinner-grow text-secondary" role="status">
    <span class="sr-only">Loading...</span>
  </div>
</div>`
      : "";
    $(books).html(html);
  }

  function failed(err) {
    console.log(err.status, err.statusText);
  }

  function succeeded(data) {
    loading(false);

    var h = function (i) {
      var authors = i.authors.reduce((r, i) => {
        var t = authorTypes[i.type];
        r += `${t}: ${i.name} `;
        return r;
      }, "");

      return `
<li class="list-group-item">
  <p class="lead">${i.title}</p>
  <p class="text-muted">
    <span>${bookType[i.type || 0]}</span>
    <span>${authors}</span>
    <span>${i.press}</span>
    <span>${i.publish_at ? i.publish_at + " 版" : ""}</span>
  </p>
  <p class="mb-1 text-muted">
    <span class="badge badge-pill ${badges[i.status]}">${i.status}</span>
    <span>${i.begin_at || "-"} to ${i.end_at || "-"}</span>
  </p>
</li>`;
    };

    var counting = function (count) {
      var html = "";
      Object.keys(badges).forEach((i) => {
        html += `<span class="mx-1 badge ${badges[i]}">${count[i] || 0}</span>`;
      });
      return html;
    };

    var n = {};

    data.forEach((i) => {
      $(books).append(h(i));
      if (!n[i.status]) n[i.status] = 1;
      else n[i.status]++;
    });

    $("#counter").html(counting(n));
  }

  loading(true);
  window.setTimeout(function () {
    $.get("books.json").done(succeeded).fail(failed);
  }, 500);
});
