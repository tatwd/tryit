!function($) {
    // 此处 $ 是 window 对象！

    // 获取 backtop 对象
    var backtop = $.document.getElementsByClassName('backtop')[0];
    
    // 监听滑块事件 
    $.addEventListener('scroll', function() {
        if($.scrollY > 0) {
            backtop.classList.add('active');    // 添加 active 类添加到对象的类列表中
        } else {
            backtop.classList.remove('active'); // 删除
        }
    }, false);

    // 为 backtop下的 icon 对象添加点击事件
    backtop.children[0].addEventListener('click', function() {
        var x = $.scrollX;
        var y = $.scrollY;
        
        var interval = $.setInterval(function() {

            if(y > 0) {
                y = y - 150; // 每次减150

                $.scrollTo(x, y);

            } else {
                $.clearInterval(interval); // 清除计时器
            }
        }, 3); // 0.003s
    }, false);

}(window);