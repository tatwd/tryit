!(function($) {
  var options = {
    el: '.backtop',
    duration: 3, // 3ms
    step: 150
  };

  var backtop = document.querySelector(options.el);

  // 显示切换
  function toggle() {
    window.scrollY > 0
      ? backtop.classList.add('active')
      : backtop.classList.remove('active');
  }

  // 返回顶部
  function back() {
    console.log(options);
    var y = window.scrollY;
    var interval = window.setInterval(function() {
      y > 0 ? (y = y - options.step) : window.clearInterval(interval); // 清除计时器
      window.scrollTo(0, y);
    }, options.duration);
  }

  // 监听滑块事件
  toggle();
  window.addEventListener('scroll', toggle, false);

  // 为 backtop 对象添加点击事件
  backtop.addEventListener('click', back, true); // true 捕获阶段执行
})();
