!function($) {

  // 下拉菜单
  //
  var dropdownMenu = function(ele, eleChild) {
    if(typeof ele != 'object' || typeof eleChild != 'object') {
        return;
    }

    ele.mouseover(function() {
      eleChild.css('display', 'block');
    });

    ele.mouseout(function() {
      eleChild.css('display', 'none');
    });
  };

  dropdownMenu($('.sort'), $('.sort-item'));
  dropdownMenu($('.serv'), $('.serv-item'));
  dropdownMenu($('.apps'), $('.apps-item'));

  // 区域隐藏
  //
  var hideGroupBody = function(ele, aimEle) {
    // console.log(ele, aimEle);

    if(typeof ele != 'object' || typeof aimEle != 'object') {
        return;
    }

    var go = function(i) {
      ele.eq(i).click(function() {
        // ele.find('img').css('transform', 'rotate(180deg)');
        console.log(this);

        aimEle.eq(i).slideToggle('slow');
      });
    }

    for (var i = 0, len = ele.length; i < len; i++) {
      go(i);
    }

  }

  hideGroupBody($('.h-rt'), $('.ls-body'));

}(jQuery);
