$(document).ready(function () {
    var leftSideBarState = abp.setting.get("UiLeftSideBarStatus");

    if (leftSideBarState == "open") {
        $('#page-container').removeClass("sidebar-mini");
    } else {
        $('#page-container').addClass("sidebar-mini");
    }


    var sidebarToggle = document.getElementsByClassName("sidebar_toggle");

    //console.log(abp.services.app.configuration);

    for (var i = 0; i < sidebarToggle.length; i++) {
        (function (index) {
            sidebarToggle[index].addEventListener("click", function () {
                if (leftSideBarState == "open") {
                    abp.services.app.configuration.changeLeftSideBarState({
                        state: "close"
                    }).done(function () {
                        //refreshRoleList();
                    });
                }
                else {
                    abp.services.app.configuration.changeLeftSideBarState({
                        state: "open"
                    }).done(function () {
                        //refreshRoleList();
                    });
                }
            })
        })(i);
    }

    //console.log(leftSideBarState);
});