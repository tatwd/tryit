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

}(jQuery);