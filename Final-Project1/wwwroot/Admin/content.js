function GetModel(marka) {
    aracMarka = $(marka).val();
    $(".selectModel").empty();
    $.ajax({
        type: "GET",
        url: "/car/getModel",
        data: { "markaId": aracMarka },
        success: function (data) {
            $(".selectModel").append("<option value =' ' > Model Seçiniz </option>")
            $.each(data, function (i, v) {
                $(".selectModel").append("<option value= '" + v.id + "' >" + v.name + "</option>")

            });
        },
        error: function (e) {
            alert(e.responseText)
        }


    });
}