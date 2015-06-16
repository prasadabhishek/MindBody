$("#grid").jqGrid({
    datatype: 'json',
    mtype: 'GET',
    colNames: ['Appointment Date', 'Start', 'End', 'Client', 'Type'],
    colModel: [
      { name: 'AppointmentDate', index: 'AppointmentDate', width: 200, align: 'center' },
      { name: 'Start', index: 'Start', width: 200, align: 'center' },
      { name: 'End', index: 'End', width: 200, align: 'center' },
      { name: 'Client', index: 'Client', width: 200, align: 'center' },
      { name: 'Type', index: 'Type', width: 200, align: 'center' }],
    pager: jQuery('#pager'),
    rowNum: 10,
    rowList: [5, 10, 20, 50],
    sortname: 'Id',
    sortorder: "desc",
    viewrecords: true,
    caption: "",
    loadonce : false
});