$(function (){
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı Silmek İstediğinizden Emin Misiniz?", function (result) { 
        if (confirm(result)) {
            var id = btn.data("id");

            $.ajax({
                type: "GET",
                url: "/Departman/Sil/" + id,
                success: function () {
                    btn.parent().parent().remove();
                }
            });
        }
            
    })
    });
});