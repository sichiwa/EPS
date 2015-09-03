// vCheckList controller
angular
	.module('app')
	.controller("vCheckListController", function (vCheckListService) {
	    var vm = this;

	    // set initial vCheckLists
	    vm.vCheckLists = [];
	    vm.vCheckLists.push({
            ListName: ''
            , Definition: ''
            , StartTime: ''
            , EndTime: ''
            , ShiftID: '00'
            , ShiftIDList: [{ id: '00', ShiftName: 'ALL' },
                            { id: '01', ShiftName: '早班' },
                            { id: '02', ShiftName: '正常班' },
                            { id: '03', ShiftName: '晚班' },
                            { id: '04', ShiftName: '假日班' }]
            , ClassID: '01'
            , ClassIDList: [{ id: '01', ClassName: '日誌' },
                            { id: '02', ClassName: '機房' },
                            { id: '03', ClassName: '環控' },
                            { id: '04', ClassName: 'Network' },
                            { id: '05', ClassName: '備份' },
                            { id: '06', ClassName: '資安' },
                            { id: '07', ClassName: 'Win Server' },
                            { id: '08', ClassName: 'CA Server' },
                            { id: '09', ClassName: 'EV SSL' },
                            { id: '10', ClassName: 'ETMP' }]
            , CheckType:'字串'
            , AlwaysShow: true
            , ChargerID: 'TAS015'
	        , ChargerList: [{ id: 'TAS015', ChargerName: '郭清章' },
                            { id: 'TAS023', ChargerName: '吳志明' },
                            { id: 'TAS046', ChargerName: '葉峯谷' },
                            { id: 'TAS070', ChargerName: '張立寰' },
                            { id: 'TAS103', ChargerName: '林依諴' },
                            { id: 'TAS105', ChargerName: '陳漢榮' },
                            { id: 'TAS143', ChargerName: '詹景安' },
                            { id: 'TAS154', ChargerName: '蔡辰陽' },
                            { id: 'TAS158', ChargerName: '張國樺' },
                            { id: 'TAS170', ChargerName: '黃富彥' },
	                        { id: 'TAS182', ChargerName: '姚茗翔' },
	                        { id: 'TAS191', ChargerName: '黃士瑋' },
	                        { id: 'TAS196', ChargerName: '王芊儒' },
	                        { id: 'TAS197', ChargerName: '吳盈杰' },
	                        { id: 'TAS199', ChargerName: '林永祿' }]
            , ShowOrder: 1
	    });

	    // add vCheckLists
	    vm.addvCheckList = function () {
	        vm.vCheckLists.push({
	        ListName: ''
            , Definition: ''
            , StartTime: ''
            , EndTime: ''
            , ShiftID: '00'
            , ShiftIDList: [{ id: '00', ShiftName: 'ALL' },
                            { id: '01', ShiftName: '早班' },
                            { id: '02', ShiftName: '正常班' },
                            { id: '03', ShiftName: '晚班' },
                            { id: '04', ShiftName: '假日班' }]
            , ClassID: '01'
            , ClassIDList: [{ id: '01', ClassName: '日誌' },
                            { id: '02', ClassName: '機房' },
                            { id: '03', ClassName: '環控' },
                            { id: '04', ClassName: 'Network' },
                            { id: '05', ClassName: '備份' },
                            { id: '06', ClassName: '資安' },
                            { id: '07', ClassName: 'Win Server' },
                            { id: '08', ClassName: 'CA Server' },
                            { id: '09', ClassName: 'EV SSL' },
                            { id: '10', ClassName: 'ETMP' }]
            , CheckType: '字串'
            , AlwaysShow: true
            , ChargerID: 'TAS015'
	        , ChargerList: [{ id: 'TAS015', ChargerName: '郭清章' },
                            { id: 'TAS023', ChargerName: '吳志明' },
                            { id: 'TAS046', ChargerName: '葉峯谷' },
                            { id: 'TAS070', ChargerName: '張立寰' },
                            { id: 'TAS103', ChargerName: '林依諴' },
                            { id: 'TAS105', ChargerName: '陳漢榮' },
                            { id: 'TAS143', ChargerName: '詹景安' },
                            { id: 'TAS154', ChargerName: '蔡辰陽' },
                            { id: 'TAS158', ChargerName: '張國樺' },
                            { id: 'TAS170', ChargerName: '黃富彥' },
	                        { id: 'TAS182', ChargerName: '姚茗翔' },
	                        { id: 'TAS191', ChargerName: '黃士瑋' },
	                        { id: 'TAS196', ChargerName: '王芊儒' },
	                        { id: 'TAS197', ChargerName: '吳盈杰' },
	                        { id: 'TAS199', ChargerName: '林永祿' }]
            , ShowOrder: 1
	        });
	    };

	    // remove vCheckLists
	    vm.removevCheckList = function (index) {
	        vm.vCheckLists.splice(index, 1);
	    };

	    // save vCheckLists
	    vm.savevCheckLists = function () {
	        vCheckListService.createvCheckList(vm).then(function () {
	            alert('done');
	            //window.location.replace('...');
	        }, function ()
	        { alert('error while posting data to server'); })
	    };
	});