$(document).ready(function () {
    $("#btnPrint").on("click", function () {
        var divContents = $("#divContents").html();
        var htmlHead = $('head').html();
        var printWindow = window.open('', '', 'height=400,width=300');
        printWindow.document.write('<html dir="rtl"><head>');
        printWindow.document.write(htmlHead);
        printWindow.document.write('</head><body>');
        printWindow.document.write('<style>body{background: white; } .span-flex{border:1px solid black; background:red; color: red; display:inline-flex;padding:10px; margin:10px;}</style>');
        printWindow.document.write(divContents);
        printWindow.document.write('</body></html>');
        printWindow.focus();
        printWindow.print();
        printWindow.document.close();
         //setTimeout(function () {
         //    printWindow.print();
         //}, 1000);
    });
});