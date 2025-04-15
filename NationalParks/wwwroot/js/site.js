document.addEventListener('DOMContentLoaded', function () {
	const deleteButtons = document.querySelectorAll('.btn-danger');

	deleteButtons.forEach((button) => {
		const toDelete = button.getAttribute('data-delete');

		button.addEventListener('click', function (event) {
			if (!confirm(`Are you sure you want to delete this ${toDelete}?`)) {
				event.preventDefault();
			}
		});
	});
});
$(document).ready(function () {
	$('#addTicketBtn')
		.off('click')
		.on('click', function (event) {
			event.preventDefault();

			var ticketSaleViewModel = {
				CardId: $('#cardId').val() || null,
				PlaceId: $('#placeId').val(),
				Ticket: {
					SaleDate: $('#saleDate').val(),
				},
			};

			console.log(ticketSaleViewModel);

			$.ajax({
				url: '/TicketSale/AddTicket',
				type: 'POST',
				contentType: 'application/json',
				data: JSON.stringify(ticketSaleViewModel),
				success: function (response) {
					$('#listaEntradas').html(response);
				},
				error: function (xhr) {
					alert('Error al agregar el ticket: ' + xhr.responseText);
				},
			});
		});
});
function removeTicket(ticketId) {
	$.ajax({
		url: '/TicketSale/RemoveTicket',
		type: 'POST',
		data: {id: ticketId},
		success: function (partialViewHtml) {
			$('#listaEntradas').fadeOut(150, function () {
				$(this).html(partialViewHtml).fadeIn(150);
			});
		},
		error: function () {
			alert('Hubo un error al intentar eliminar el ticket.');
		},
	});
}

$(document).on('click', '.delete-ticket-btn', function () {
	var ticketId = $(this).data('ticket-id');
	removeTicket(ticketId);
});
$('#btnVender').click(function () {
	$.post('/Venta/Vender', function () {
		alert('Venta realizada con éxito.');
		location.reload();
	});
});
