// Добавление атрибута hidden первому элементу dropdownlist
function AddAttributeHiddenToFirstChildList(NameList) {
    var selector = "#" + NameList + ">option:first-child";
    $(selector).attr("hidden", "");
};
// Добавление списка выбранной мебели на страницу
function AjaxPost(event, role) {
    var value = event.target.value;
    var formdata = new FormData();
    formdata.append("IdStuff", value);
    formdata.append("role", role);
    $.ajax
    ({
        url: "/Home/AccordingToRole",
        type: 'POST',
        data: formdata,
        cache: false,
        processData: false,
        contentType: false,
        success: function (respond, status, jqXHR) {
            if (typeof respond.error === 'undefined') {
                $("#Stuff").html(respond);
            }
            else {
                console.log('ОШИБКА: ' + respond.error);
            }
        },
        error: function (jqXHR, status, errorThrown) {
            console.log('ОШИБКА AJAX запроса: ' + status, jqXHR);
        }
    });
};
// Удаление элемента через web api
function AjaxDelete(path, tr) {
        $.ajax
        ({
            url: path,
            type: 'DELETE',
            success: function (respond, status, jqXHR) {
                if (typeof respond.error === 'undefined') {
                    tr.remove();
                }
                else {
                    console.log('ОШИБКА: ' + respond.error);
                }
            },
            error: function (jqXHR, status, errorThrown) {
                console.log('ОШИБКА AJAX запроса: ' + status, jqXHR);
            }
        });
};
$(document).ready(function () {
    AddAttributeHiddenToFirstChildList("BedRoom");
    AddAttributeHiddenToFirstChildList("Kitchen");
    // Добавление списка выбранной мебели
    $(document).on("change", "#BedRoom", function (event) {
        var role = $("#role").attr("data-role");
        AjaxPost(event, role);
    });
    // Добавление списка выбранной мебели
    $(document).on("change", "#Kitchen", function (event) {
        var role = $("#role").attr("data-role");
        AjaxPost(event,role);
    });
    // Удаление элемента
    $(document).on("click", ".link", function (event) {
        var value = $(this).attr("value");
        var path = "http://localhost:49433/api/FurnitureList?id=" + value;
        var tr = $(this).closest("tr");
        AjaxDelete(path,tr);
       
    });
    // Удаление элемента из корзины пользователя
    $(document).on("click", ".eject", function (event) {
        var value = $(this).attr("value");
        var tr = $(this).closest("tr");
        var formdata = new FormData();
        formdata.append("IdFurniture", value);
        $.ajax
        ({
            url: "/User/EjectFurnitureFromCrate",
            type: 'POST',
            data: formdata,
            cache: false,
            processData: false,
            contentType: false,
            success: function (respond, status, jqXHR) {
                if (typeof respond.error === 'undefined') {
                    tr.remove();
                }
                else {
                    console.log('ОШИБКА: ' + respond.error);
                }
            },
            error: function (jqXHR, status, errorThrown) {
                console.log('ОШИБКА AJAX запроса: ' + status, jqXHR);
            }
        });
    });
    // Динамическое изменение фото на странице
    $(document).on("change", "input[type=file]", function (event) {
        var file = event.target.files[0];
        reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function (event) {
            dataUri = event.target.result;
            $("#image").attr("src", dataUri);
        };
    });
    // Изменение корзины пользователя
    $(document).on("click", ".crate", function (event) {
        var value = $(this).attr("value");
        var formdata = new FormData();
        formdata.append("id", value);
        $.ajax
     ({
         url: '/User/Crate',
         type: 'POST',
         data: formdata,
         cache: false,
         processData: false,
         contentType: false,
         success: function (respond, status, jqXHR) {
             if (typeof respond.error === 'undefined') {
                 $("#Crate").html(respond);
             }
             else {
                 console.log('ОШИБКА: ' + respond.error);
             }
         },
         error: function (jqXHR, status, errorThrown) {
             console.log('ОШИБКА AJAX запроса: ' + status, jqXHR);
         }
     });
    });
});