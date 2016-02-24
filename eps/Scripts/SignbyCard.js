//讀取ActiveX
if (typeof myobj == "undefined") {
    document.write('<OBJECT id="myobj" codebase="POSTATX.cab#version=1,0,0,1" classid="clsid:D1504008-EB4C-4A2B-8BD7-2B19105A68AA" VIEWASTEXT></OBJECT>');
}


//憑證登入前端處理
function SignData(Plaintext,nowAccount) {
    //alert('c');
    var Result = "fail";
    //連接讀卡機
    var retSetTokenType = myobj.SetTokenType(2);
    if (retSetTokenType != "0") {
        alert('連結卡片失敗,Return Code:' + retSetTokenType + 'ErrMsg:' + myobj.GetErrorMsg());
        // location.reload();
        return Result;
    }
    else {
        //登入卡片
        //alert('元件OK');
    
        var retGetCardStatus = myobj.GetCardStatus();

        if (retGetCardStatus == 0) {
            var PINCode = document.getElementById("CertPwd"); // var PINCode = "12345678";
            //alert(PINCode.value);
            var retLogin = myobj.Login(PINCode.value);
            if (retLogin == 0) {
                //alert('卡片登入成功');
                var cert = myobj.SelectCert(2);
                if (cert == 0) {
                    var subject = myobj.GetSelectedCertSubject();
                    //alert('subject:' + subject);
                    //切割Subject
                    var subjectarr = subject.split("/");
                    //抓CN資料
                    var TmpCN = subjectarr[6];
                    //alert('CN含=:' + TmpCN);
                    //去掉CN=
                    TmpCN = TmpCN.split("=")[1];
                    //alert('CN不含=:' + TmpCN);
                    //切割CN
                    var CNarr = TmpCN.split("-");
                    //抓員工編號
                    var Account = CNarr[2].toLowerCase();
                    nowAccount = nowAccount.toLowerCase();
                    //alert('Account:'+ Account);
                    //alert('nowAccount:' + nowAccount);
                
                    if (nowAccount == Account) {
                        //組簽章本文(Session id+員工編號+現在時間)
                        //var Symbol = "|"
                        //var SessionId = document.getElementById("SessionIdhid").value
                        //alert('SessionId:' + SessionId);
                        //var now = new Date();
                        //組時間yyyy/MM/dd hh:mm:ss
                        //var now1 = now.getFullYear() + '/' + (now.getMonth() + 1) + '/' + now.getDate() + ' ' + now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
                        //alert('Datetime:' + now);
                        //var BeSignedData = getData(SessionId, Account, now1, Symbol)
                        //var BeSignedData = getData(Account, now1, Symbol)
                        //var Plaintexthid = document.getElementById("Plaintext")
                        //alert('簽章本文:' + BeSignedData);
                        //BeSignedData = fetchAscii(BeSignedData)
                        //Plaintexthid.value = BeSignedData
                        //alert('簽章本文:' + BeSignedData);
                        //var Datatbx = document.getElementById("Datatbx")
                        //Datatbx.value = BeSignedData
                        //簽章
                        var retSignPKCS7 = myobj.SignPKCS7(Plaintext);
                        //alert('簽章結果:' + retSignPKCS7);
                        if (retSignPKCS7 == 0) {
                            //將簽章值Show在SignDatatbx
                            //var SignDatatbx = document.getElementById("SignDatatbx")
                            //var SignDatahid = document.getElementById("SignData")
                            //SignDatatbx.value = myobj.GetPKCS7Data();
                            var Result = myobj.GetPKCS7Data();
                            //alert(myobj.GetPKCS7Data());
                            return Result;
                            //alert('簽章值:' + SignDatahid.value);
                            //var SignData = myobj.GetPKCS7Data();
                        }
                        else {
                            alert('簽章失敗,Return Code:' + retSignPKCS7 + 'ErrMsg:' + myobj.GetErrorMsg() + 'Funcation:SignPKCS7');
                            //location.reload();
                            return Result;
                        }
                    }
                    else {
                        alert('憑證CN與登入帳號不符' + 'Funcation:SignPKCS7');
                        //location.reload();
                        return Result;
                    }
                }
                else {
                    alert('讀取憑證失敗,Return Code:' + cert + 'ErrMsg:' + myobj.GetErrorMsg() + 'Funcation:SelectCert');
                    //location.reload();
                }
            }
            else {
                alert('卡片登入失敗,Return Code:' + retLogin + 'ErrMsg:' + myobj.GetErrorMsg() + 'Funcation:Login');
                //location.reload();
                return Result;
            }
        }
        else {
            alert('取得卡片狀態失敗,Return Code:' + retGetCardStatus + 'ErrMsg:' + myobj.GetErrorMsg() + 'Funcation:SetTokenType');
            //location.reload();
            return Result;
        }
    }
}

//組合簽章本文
//function getData(_Account, _now, _Symbol) {
//    return _Symbol + _Account + _Symbol + _now
//}

//function getData(_SessionId, _Account, _now, _Symbol) {
//    return _SessionId + _Symbol + _Account + _Symbol + _now
//}


