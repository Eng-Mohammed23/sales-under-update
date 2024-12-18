
$(document).ready(function () {
    $('#headd').addClass("d-none");

    //$('#DelegateForm').delegate("#ItemId", 'change', function () {
    $("#ItemId").on('change', function () {
        var id = $(this).val();
        if (id !== '') {
            $.ajax({
                url: '/Orders/GetQualityPrices?id=' + id,
                success: function (ids) {

                    $("#Quantity1").text(ids.srtQuality1);
                    $("#Quantity2").text(ids.srtQuality2);
                    $("#Quantity3").text(ids.srtQuality3);

                    $("#store1").text("صاله العرض : " + ids.stor1);
                    $("#store2").text("مخزن 1 : " + ids.stor2);
                    $("#store3").text("مخزن 2 : " + ids.stor3);

                    //onclick by Default when it is active
                    // تنفيذ وظيفة onclick تلقائيًا
                    $(document).ready(function () {
                        for (var i = 1; i <= 3; i++) {
                            var $element = $('#Quantity' + i);
                            if ($element.hasClass('active')) {
                                $element.trigger('click');
                            }
                        }
                        for (var i = 1; i <= 3; i++) {
                            var $element = $('#store' + i);
                            if ($element.hasClass('active')) {
                                $element.trigger('click');
                            }
                        }
                    });

                    $("#TheSourcePrice").val(ids.srcPrice);


                    $('#Quantity1').on('click', function () {
                        $('#ThePrice').val(ids.q1);
                        $('#SortOfQuantity').val(ids.srtQuality1);
                        $('#Quantity1').addClass('active');
                        $('#Quantity2').removeClass('active');
                        $('#Quantity3').removeClass('active');

                        $('#Number').val(1);
                        $('#TotalOfPrice').val($('#ThePrice').val());

                        $('#dropdownMenuButton').text($('#Quantity1').text());
                    });


                    $('#Quantity2').on('click', function () {
                        $('#ThePrice').val(ids.q2);
                        $('#SortOfQuantity').val(ids.srtQuality2);
                        $('#Quantity2').addClass('active');
                        $('#Quantity1').removeClass('active');
                        $('#Quantity3').removeClass('active');

                        $('#Number').val(1);
                        $('#TotalOfPrice').val($('#ThePrice').val());

                        $('#dropdownMenuButton').text($('#Quantity2').text());
                    });
                    $('#Quantity3').on('click', function () {
                        $('#ThePrice').val(ids.q3);
                        $('#SortOfQuantity').val(ids.srtQuality3);
                        $('#Quantity3').addClass('active');
                        $('#Quantity2').removeClass('active');
                        $('#Quantity1').removeClass('active');

                        $('#Number').val(1);
                        $('#TotalOfPrice').val($('#ThePrice').val());

                        $('#dropdownMenuButton').text($('#Quantity3').text());
                    });
                    $('#Title').val(ids.title);

                    $('#ThePrice').on('change', function () {
                        $('#Number').val(1);
                        $("#TotalOfPrice").val($('#ThePrice').val());
                    });
                    $('#Number').on('change', function () {
                        if ($('#ThePrice').val() > 0) {
                            $('#TotalOfPrice').val($('#Number').val() * $('#ThePrice').val());
                        }
                        else {
                            $('#TotalOfPrice').val(0);
                        }
                    });
                    $('#TotalOfPrice').on('change', function () {
                        var valueOfPrice;
                        if ($('#Quantity1').hasClass('active')) {
                            valueOfPrice = ids.q1;
                        }
                        if ($('#Quantity2').hasClass('active')) {
                            valueOfPrice = ids.q2;
                        }
                        if ($('#Quantity3').hasClass('active')) {
                            valueOfPrice = ids.q3;
                        }
                        $('#Number').val(parseFloat(($('#TotalOfPrice').val()) / valueOfPrice).toFixed(2));

                    });

                },
                error: function () {
                }
            });
        }
    });



    $("#SelectClientUp").on('change', function () {
        var id = $(this).val();
        $("#ClientId").val(id);


        if (id !== '' || id == 0) {
            $.ajax({
                url: '/Orders/GetTheRestOfClient?id=' + id,
                success: function (client) {
                    $("#srtQuality").text(client.srt);
                    $("#account").text("حسابه  " + client.act);
                    $('#city').text("البلد " + client.city);
                    $('#teleph').text(" التليفون " + client.teleph);
                },
                error: function () {
                }
            });
        }
    });

    $("#Total").on('change', function () {
        $("#AfterDiscount").val($("#Total").val() - $("#Discount").val());
    });
    $("#Discount").on('change', function () {
        $("#AfterDiscount").val($("#Total").val() - $("#Discount").val());
    });


    $("#Payment").on("change", function () {

        $("#TheRest").val($("#AfterDiscount").val() - $("#Payment").val());
    });



});


$('#Store').on('click', function () {
    $('#ToStore').val(true);
});

$('#store1').on('click', function () {
    $('#NumOfStore').val(1);

    $('#store1').addClass('active');
    $('#store2').removeClass('active');
    $('#store3').removeClass('active');
    $('#dropdownStore').text($('#store1').text());
});
$('#store2').on('click', function () {
    $('#NumOfStore').val(2);

    $('#store2').addClass('active');
    $('#store1').removeClass('active');
    $('#store3').removeClass('active');
    $('#dropdownStore').text($('#store2').text());
});
$('#store3').on('click', function () {
    $('#NumOfStore').val(3);

    $('#store3').addClass('active');
    $('#store2').removeClass('active');
    $('#store1').removeClass('active');
    $('#dropdownStore').text($('#store3').text());
});



function onAddCopySuccess(copy) {

    $('#CopiesForm').append(copy);

    $("#Total").val(function (index, currentVal) {
        return parseFloat(currentVal) + parseFloat($("#totPrice").val());
    });
    $("#no-invoice").removeClass('d-none').addClass('d-flex flex-column').addClass();
    $("#seperator").removeClass('mb-7').removeClass('p-3');

    var copies = $('.js-copy');

    selectedCopies = [];

    $.each(copies, function (i, input) {
        var $input = $(input);
        selectedCopies.push({ serial: $input.val(), bookId: $input.data('book-id') });
        $input.attr('name', `Title[${i}]`).attr('id', `Title_${i}_`);
    });


    var numbers = $('.js-num');

    //selectedNumbers = [];

    $.each(numbers, function (i, input) {
        var $input = $(input);
        //selectedNumbers.push({serial: $input.val(), bookId: $input.data('book-id') });
        $input.attr('name', `SortOfNum[${i}]`).attr('id', `SortOfNum_${i}_`);
    });

    var itemId = $('.js-item-id');

    selectedItemId = [];

    $.each(itemId, function (i, input) {
        var $input = $(input);
        selectedItemId.push({ serial: $input.val(), bookId: $input.data('book-id') });
        $input.attr('name', `SelectedItems[${i}]`).attr('id', `SelectedItems_${i}_`);
    });
    $('#ItemId').val("");
}


document.addEventListener('DOMContentLoaded', function () {
    const formElements = document.querySelectorAll('input, select');

    formElements.forEach((element, index) => {
        element.addEventListener('keydown', function (e) {
            if (e.key === 'Enter') {
                e.preventDefault();
                const nextElement = formElements[index + 2];
                if (nextElement) {
                    nextElement.focus();

                }

                if (nextElement.id === 'finish') {
                    formElements[index - 2].focus();
                    $("#addForm").submit();
                }


            }
        });
    });
});


