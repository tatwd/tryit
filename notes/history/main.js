$(function() {
  var BASE_API_URL = 'https://api.ctext.org/';
  var dynastiesDom = $('#dynasties');
  var renderDynasties = function(data) {
    var s = '';
    $.each(data, function(idx, item) {
      // console.log(item);
      var from = Number(item.yearfrom);
      var to = Number(item.yearto);
      var span = Math.abs(to - from) + 1;
      from = from < 0 ? '前 ' + -from : ' ' + from;
      to = to < 0 ? '前 ' + -to : ' ' + to;
      s += `
<div class="col-sm-4 pb-3">
  <div class="card">
    <div class="card-body">
      <h5 class="lead">${item.title}</h5>
      <p class="card-text">
        公元${from} ~ ${to} 年 <br>
        <small>历时：${span} 年</small>
      </p>
    </div>
  </div>
</div>`;
    });
    dynastiesDom.html(s);
  };
  var getDynasties = function() {
    var old_data = localStorage.getItem('dynasties');
    old_data && renderDynasties(JSON.parse(old_data));
    $.get(BASE_API_URL + 'getdynasties?if=zh&remap=gb')
      .done(function(data, type, xhr) {
        var lastmodified = localStorage.getItem('getdynasties_saved_at');
        var now = Date.now();
        if (!lastmodified || now - lastmodified > 1 * 3600 * 1000) {
          localStorage.setItem('getdynasties_saved_at', now);
          localStorage.setItem('dynasties', JSON.stringify(data.dynasties));
        }
        !old_data && renderDynasties(data.dynasties);
      })
      .fail(function(err) {
        console.log(err);
      });
  };
  setTimeout(() => {
    getDynasties();
  }, 500);
});
