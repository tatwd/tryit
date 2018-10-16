!function($) {
    // 此处 $ 是 window 对象！

    // 获取 backtop 对象
    var backtop = $.document.getElementsByClassName('backtop')[0];
    
    // 监听滑块事件 
    $.addEventListener('scroll', function() {

        ($.scrollY > 0) ? 
            backtop.classList.add('active') :   // 添加 active 类
            backtop.classList.remove('active'); // 删除 active 类
        
    }, false);

    // 为 backtop 对象添加点击事件
    backtop.addEventListener('click', function() {
        var x = $.scrollX;
        var y = $.scrollY;
        
        var interval = $.setInterval(function() {

            (y > 0) ? y = y - 150: $.clearInterval(interval); // 清除计时器

            $.scrollTo(x, y);
            
        }, 3); // 0.003s

    }, true);  // true 捕获阶段执行 

}(window);