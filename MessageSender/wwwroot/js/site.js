// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function SendMessage(e) {
    event.preventDefault();
    var data = $("#SendMessageTemplate");
    
        $.ajax({
            type: 'POST',
            url: "/Home/Index",
            data: data.serialize(),
            beforeSend: function () {
            fnButtonLoader(e);
            },
            success: function (data) {
                alert(data);
            },
            error: function (xhr) { // if error occured
                alert("Error occured.please try again" + xhr.statusText + xhr.responseText);

            },
            complete: function () {
                fnUpdateBtnDisableData(e)
            },
            dataType: 'html'
        });
    }

function fnButtonLoader(e) {
    var $btn = $(e);
    $('*').off('click', fnRemoveBtnDisable);
    $btn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>').prop('disabled', true);
}

function fnUpdateBtnDisableData(e) {
    var $btn = $(e);
    $btn.html("Save").prop('disabled', false);
}

function fnRemoveBtnDisable(e) {
    var $btn = $(e);

    $btn.html(imgBtnText).prop('disabled', false);
}