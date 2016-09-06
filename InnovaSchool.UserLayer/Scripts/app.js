$(function () {
    $(document).ajaxError(function (a, b, c) {
        switch (b.status) {
            case 404: console.log('Error 404: El recurso solicitado no existe o no está disponible'); break;
            case 403: appMaster.MessageBox('No autorizado', 'Ud. no tiene permisos para ejecutar la acción solicitada'); break;
        }
    });

    $('body').on('keypress', 'input:text', function (e) {
        if (e.keyCode == 13) return false;
    });
});
