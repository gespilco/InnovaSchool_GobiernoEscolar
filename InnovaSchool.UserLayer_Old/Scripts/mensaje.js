function GenerarMensaje(titulo, mensaje) {
    var alerta;
    alerta = '<div class="modal hide fade in" id="myModal">' +
		        '<div class="modal-header">' +
			        '<button type="button" class="close" data-dismiss="modal">×</button>' +
			        '<h2>' + titulo + '</h2>' +
		            '</div>' +
		            '<div class="modal-body">' +
			            '<p>' + mensaje + '</p>' +
		            '</div>' +
		            '<div class="modal-footer">' +
			            '<a href="#" class="btn btn-primary" data-dismiss="modal">Aceptar</a>' +
		        '</div>' +
	         '</div>';
    return alerta;
}
function myModalShow()
{
    $('#myModal').modal('show');
}