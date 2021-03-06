﻿
var employee;
var events = [];
var employeeShifts = [];

function OnCheckBoxSelect() {
    if (document.getElementById("OnlyMyShifts").checked) {
        $('#calendar').fullCalendar("removeEvents");
        $("#calendar").fullCalendar('addEventSource', employeeShifts);
        $('#calendar').fullCalendar("refresh");
    }
    else {
        $('#calendar').fullCalendar("removeEvents");
        $("#calendar").fullCalendar('addEventSource', events);
        $('#calendar').fullCalendar("refresh");
    }

}



$(document).ready(function () {


    GetLogginInEmployee();
    FetchEventAndRenderCalendar();
    GetShiftsByEmployee();



    function GetShiftsByEmployee() {
        $.ajax({
            type: "GET",
            url: "/Home/GetShiftsByEmployee",
            success: function (data) {
                $.each(data, function (i, v) {
                    var col;
                    if (v.IsForSale == false) {
                        col = 'blue';
                    }
                    else {
                        col = 'red';
                    }
                    employeeShifts.push({
                        eventID: v.Id,
                        title: v.Employee.Name,
                        start: moment(v.StartTime),
                        end: moment(v.StartTime).clone().add(v.Hours, 'hour'),
                        color: col,
                        allDay: false
                    });
                })
            },
            error: function (error) {
                alert('failed');
            }
        });
    }

    function GetLogginInEmployee() {
        $.ajax({
            type: "GET",
            url: "/Home/GetLoggedInEmployee",
            success: function (data) {
                employee = data.Name;
            },
            error: function (error) {
                alert('failed');
            }
        })
    }


    function FetchEventAndRenderCalendar() {
        $.ajax({
            type: "GET",
            url: "/Home/GetEvents",
            async: true,
            success: function (data) {

                $.each(data, function (i, v) {
                    var col;
                    if (v.IsForSale == false) {
                        col = 'blue';
                    }
                    else {
                        col = 'red';
                    }
                    events.push({
                        eventID: v.Id,
                        title: v.Employee.Name,
                        start: moment(v.StartTime),
                        end: moment(v.StartTime).clone().add(v.Hours, 'hour'),
                        color: col,
                        allDay: false
                    });
                })

                GenerateCalendar(events);
            },
            error: function (error) {
                alert('failed');
            }
        })
    };


    function ReloadEvents() {

        if (document.getElementById("OnlyMyShifts").checked) {
            employeeShifts = [];
            $.ajax({
                type: "GET",
                url: "/Home/GetShiftsByEmployee",
                success: function (data) {
                    $.each(data, function (i, v) {
                        var col;
                        if (v.IsForSale == false) {
                            col = 'blue';
                        }
                        else {
                            col = 'red';
                        }
                        employeeShifts.push({
                            eventID: v.Id,
                            title: v.Employee.Name,
                            start: moment(v.StartTime),
                            end: moment(v.StartTime).clone().add(v.Hours, 'hour'),
                            color: col,
                            allDay: false
                        });
                    })
                    $('#calendar').fullCalendar("removeEvents");
                    $("#calendar").fullCalendar('addEventSource', employeeShifts);
                    $('#calendar').fullCalendar("refresh");
                },
                error: function (error) {
                    alert('failed');
                }
            });
        }
        else {
            events = [];
            $.ajax({
                type: "GET",
                url: "/Home/GetEvents",
                success: function (data) {

                    $.each(data, function (i, v) {
                        var col;
                        if (v.IsForSale == false) {
                            col = 'blue';
                        }
                        else {
                            col = 'red';
                        }
                        events.push({
                            eventID: v.Id,
                            title: v.Employee.Name,
                            start: moment(v.StartTime),
                            end: moment(v.StartTime).clone().add(v.Hours, 'hour'),
                            color: col,
                            allDay: false
                        });
                    });

                    $('#calendar').fullCalendar("removeEvents");
                    $("#calendar").fullCalendar('addEventSource', events);
                    $('#calendar').fullCalendar("refresh");
                },
                error: function (error) {
                    alert('failed');
                }

            });
        }

    }

    function GenerateCalendar(events) {

        $('#external-events .fc-event').each(function () {

            // store data so the calendar knows to render an event upon drop
            $(this).data('event', {
                title: $.trim($(this).text()), // use the element's text as the event title
                stick: true // maintain when user navigates (see docs on the renderEvent method)
            });

            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 999,
                revert: true,      // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            });
        });

        $('#calender').fullCalendar('destroy');
        $('#calendar').fullCalendar({
            contentHeight: 500,
            defaultDate: new Date(),
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay,listMonth, myCustomButton'
            },
            slotDuration: '00:30:00',
            buttonIcons: false, // show the prev/next text
            weekNumbers: true,
            timeFormat: '(hh:mm)a',
            defaultView: 'agendaWeek',
            navLinks: true, // can click day/week names to navigate views
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            locale: "au",
            events: events,
            editable: false,
            snapDuration: '00:05:00',
            forceEventDuration: true,
            drag: function () {
                confirm('Do you want to drag it?');
            },
            droppable: false, // this allows things to be dropped onto the calendar
            drop: function (date) {
                // is the "remove after drop" checkbox checked?
                if ($('#drop-remove').is(':checked')) {
                    // if so, remove the element from the "Draggable Events" list
                    $(this).remove();
                }
            },
            eventClick: function (calEvent, jsEvent, view) {

                if (employee == calEvent.title) {
                    if (calEvent.color == 'red') {
                        swal({
                            title: "This shift is already set as availble",
                            text: "Do you wish to take it back?",
                            icon: "warning",
                            buttons: true,
                            dangerMode: true,
                        })
                            .then((willDelete) => {
                                if (willDelete) {
                                    swal("This shift is now yours again", {
                                        icon: "success",
                                    });
                                    AcceptAvailableShift(calEvent);
                                    ReloadEvents();
                                } else {
                                    swal("No worries, we all click wrong from time to time");
                                }
                            });
                    }
                    else {
                        swal({
                            title: "Are you sure?",
                            text: "This shift will be marked as available",
                            icon: "warning",
                            buttons: true,
                            dangerMode: true,
                        })
                            .then((willDelete) => {
                                if (willDelete) {
                                    swal("Your shift is now set as avaible", {
                                        icon: "success",
                                    });
                                    SetShiftForSale(calEvent);
                                    ReloadEvents();
                                } else {
                                    swal("No worries");
                                }
                            });
                    }

                }
                else if (calEvent.color == 'red') {
                    swal({
                        title: "Do you wish to accept this shift?",
                        text: "From: " + calEvent.title + " Date: " + moment(calEvent.start).format('YYYY-MM-DD') + " Time: " +
                        moment(calEvent.start).format('HH:mm') + " - " + moment(calEvent.end).format('HH:mm'),
                        icon: "warning",
                        buttons: true,
                        dangerMode: true,
                    })
                        .then((willDelete) => {
                            if (willDelete) {

                                AcceptAvailableShift(calEvent);
                                ReloadEvents();
                            } else {
                                swal("No worries, we all click wrong from time to time");
                            }
                        });
                }
                else {
                    swal('You can only set your own shift for sale!')
                }
            },

        });
    }

    var checkboxContainer = $('#CheckBoxDiv');

    // Append it to FullCalendar.
    $(".fc-right").append($('#CheckBoxDiv'));

    function Save() {
        $.each($('#calendar').fullCalendar('clientEvents'), function (i, v) {
            var event = {
                EventID: v.eventID,
                Subject: v.title,
                Start: v.start,
                End: v.end,
                Description: v.description,
                ThemeColor: v.color,
                IsFullDay: v.allDay
            }
            SaveEvent(event);
        });
    }

    function SaveEvent(event) {
        $.ajax({
            url: '/Home/SaveEvent',
            type: 'POST',
            data: JSON.stringify(event),
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function () {
                alert(data);
            },
            error: function () {
                alert("error");
            }
        });
    }

    function SetShiftForSale(calEvent) {

        var event = {
            Id: calEvent.eventID,
            StartTime: calEvent.start,
            Hours: 4,
            IsForSale: false,
            Employee: { Name: calEvent.title }
        }
        $.ajax({
            url: '/Home/SetShiftForSale',
            type: 'POST',
            data: JSON.stringify(event),
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function () {

                //$(this).css('background-color', 'red');

                //alert(JSON.stringify(event));
            },
            error: function () {
                alert("error");
            }
        });
    }

    function AcceptAvailableShift(calEvent) {

        var event = {
            Id: calEvent.eventID,
            StartTime: calEvent.start,
            Hours: 4,
            IsForSale: true,
            Employee: { Name: calEvent.title }
        }
        $.ajax({
            url: '/Home/AcceptShift',
            type: 'POST',
            data: JSON.stringify(event),
            contentType: 'application/json; charset=utf-8',
            async: false,
            success: function () {
                swal("This shift is now yours!", {
                    icon: "success",
                });
                $(this).css('background-color', 'blue');

            },
            error: function () {
                swal("Error! Shift already accepted! Too slow!")
            }
        });
    }

});

