var selectedCopies = [];
$(document).ready(function () {
    $('.js-select2').select2({
        //placeholder: "الاسم",
        //width: '100%', // لضمان أن الحقل يأخذ العرض الكامل
        theme: 'classic' // يمكنك استخدام الثيم الافتراضي أو تخصيص ثيم مخصص
    });
});

function disableSubmitButton() {
    $('body :submit').attr('disabled', 'disabled').attr('data-kt-indicator', 'on');
}
function onModalComplete() {
    $('body :submit').removeAttr('disabled').removeAttr('data-kt-indicator');
}

function onAddCopySuccess(copy) {
    $('#CopiesForm').prepend(copy);
}


function scrollToBottom() {
    window.scrollTo({
        top: 0,//document.body.scrollHeight,
        behavior: 'smooth'
    });
}

function printContent() {
    printJS({
        printable: 'print-js',
        type: 'html',
        showModal: false
    });
}


