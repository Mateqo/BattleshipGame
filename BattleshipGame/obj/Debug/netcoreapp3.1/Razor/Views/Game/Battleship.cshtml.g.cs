#pragma checksum "D:\Users\User\Desktop\repozytorium\BattleshipGame\BattleshipGame\Views\Game\Battleship.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bbdd16d40eac090f88daafbe83d4fd376e1069f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Battleship), @"mvc.1.0.view", @"/Views/Game/Battleship.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Users\User\Desktop\repozytorium\BattleshipGame\BattleshipGame\Views\_ViewImports.cshtml"
using BattleshipGame;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\User\Desktop\repozytorium\BattleshipGame\BattleshipGame\Views\_ViewImports.cshtml"
using BattleshipGame.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bbdd16d40eac090f88daafbe83d4fd376e1069f", @"/Views/Game/Battleship.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3f18e7eac5cb37899935c977ab3e690f105c62b", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Battleship : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section>
    <div class=""ml-auto mr-auto title"">
        <span>Battleship</span>
    </div>
    <div class=""ml-auto mr-auto start"">
        <button id=""start"" onclick=""startGame();"" type=""button"" class=""btn"">Start simulation</button>
    </div>
    <div class=""end"" style=""display:none"">
        <span id=""endText""></span>
    </div>
    <div class=""cards"">
        <!--You-->
        <div id=""yourBoard"" class=""card"">
            <div class=""spinner-border text-primary"" role=""status"" style=""display:none"">
                <span class=""sr-only"">Loading...</span>
            </div>
            <span class=""positionHorizontal"">1 &nbsp;&ensp; 2 &ensp; 3 &nbsp;&nbsp; 4 &nbsp;&nbsp; 5 &nbsp;&nbsp; 6 &nbsp;&nbsp; 7 &nbsp;&ensp; 8 &nbsp;&nbsp; 9 &nbsp; 10</span>
            <ul class=""positionVertical""><li>A</li><li style=""margin-top:-2px;"">B</li><li style=""margin-top:-2px;"">C</li><li style=""margin-top:-2px;"">D</li><li style=""margin-top:-2px;"">E</li><li>F</li><li style=""margin-top:-2px;"">G</li><li style");
            WriteLiteral(@"=""margin-top:-2px;"">H<li style=""margin-top:-3px;"">I</li><li style=""margin-top:-2px;"">J</li></ul>
            <span class=""player"">You</span>
            <div id=""yourTurn"" class=""spinner-grow text-light"" role=""status"" style=""display:none"">
                <span class=""sr-only"">Loading...</span>
            </div>
        </div>

        <!--Bot-->
        <div id=""botBoard"" class=""card"">
            <i onclick=""showShips();"" class=""fas fa-eye"" style=""display:none;""></i>
            <i onclick=""hideShips();"" class=""fas fa-eye-slash"" style=""display:none;right:8px !important;""></i>
            <div class=""spinner-border text-primary"" role=""status"" style=""display:none"">
                <span class=""sr-only"">Loading...</span>
            </div>
            <span class=""positionHorizontal"">1 &nbsp;&ensp; 2 &ensp; 3 &nbsp;&nbsp; 4 &nbsp;&nbsp; 5 &nbsp;&nbsp; 6 &nbsp;&nbsp; 7 &nbsp;&ensp; 8 &nbsp;&nbsp; 9 &nbsp; 10</span>
            <ul class=""positionVertical""><li>A</li><li style=""margin-top:-2px;"">B");
            WriteLiteral(@"</li><li style=""margin-top:-2px;"">C</li><li style=""margin-top:-2px;"">D</li><li style=""margin-top:-2px;"">E</li><li>F</li><li style=""margin-top:-2px;"">G</li><li style=""margin-top:-2px;"">H<li style=""margin-top:-3px;"">I</li><li style=""margin-top:-2px;"">J</li></ul>
            <span class=""player"">Bot</span>
            <div id=""botTurn"" class=""spinner-grow text-light"" role=""status"" style=""display:none"">
                <span class=""sr-only"">Loading...</span>
            </div>
        </div>
    </div>


    <!--animation-->
    <div class=""waves"">
        <div class=""wave wave1""></div>
        <div class=""wave wave2""></div>
        <div class=""wave wave3""></div>
        <div class=""wave wave4""></div>
    </div>
</section>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            for (var i = 0; i < 10; i++) {
                for (var j = 0; j < 10; j++) {
                    $('#yourBoard').append('<div id=""' + ""you"" + i + j + '"" class=""field""></div>');
                    $('#botBoard').append('<div id=""' + ""bot"" + i + j + '"" class=""field""></div>');
                }
            }
        });
        function showShips() {
            $('.hideShip').show();
            $('.fa-eye').hide();
            $('.fa-eye-slash').show();
        }
        function hideShips() {
            $('.hideShip').hide();
            $('.fa-eye-slash').hide();
            $('.fa-eye').show();
        }
        function startGame() {
            clearBoards();
            $('.spinner-border').show();
            $('.field').css('border', 'none');
            setTimeout(generateShips, 500);
        }
        function clearBoards() {
            $('.shipHorizontalLeft').remove();
          ");
                WriteLiteral(@"  $('.shipHorizontalRight').remove();
            $('.shipHorizontalMid').remove();
            $('.shipVerticalDown').remove();
            $('.shipVerticalUp').remove();
            $('.shipVerticalMid').remove();
            $('.fa-bomb').remove();
            $('.fa-times').remove();
            $('.end').hide();
            isYourTurn = false;
            isEnd = false;
            isHit = false;
        }
        function generateShips() {
            $.ajax({
                url: '/Game/GenerateBoards',
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    if (data.success) {
                        displayShipsOnBoard(""you"", data.yourShips);
                        displayShipsOnBoard(""bot"", data.botShips);
                        isYourTurn = Math.random() < 0.5;
                        gameLogic();
                    }
                    else {
                        console.log('Failed!');
         ");
                WriteLiteral(@"           }
                },
                error: function () {
                    console.log('Failed!');
                },
                complete: function () {
                    $('.spinner-border').hide();
                    $('.field').css('border', 'grey solid 1px');
                    $('#start').text(""Restart"");
                    $('.fa-eye').show();
                }
            });
        }
        var isYourTurn;
        var isEnd;
        var isHit;
        function gameLogic() {
            if (!isHit)
                isYourTurn = !isYourTurn;


            //loading spinner
            if (isYourTurn) {
                $('#yourTurn').show();
                $('#botTurn').hide();
            }
            else {
                $('#botTurn').show();
                $('#yourTurn').hide();
            }

            if (isEnd) {
                $('.end').show();
                if (isYourTurn)
                    $('#endText').text('YOU WIN');
    ");
                WriteLiteral(@"            else
                    $('#endText').text('YOU LOSE');
                $('.end').show();
                return;
            }
            setTimeout(function () {
                if (isYourTurn) {
                    shoot(""You"", ""bot"")
                }
                else {
                    shoot(""Bot"", ""you"")
                }
            }, 1000);
        }
        function shoot(Player, player) {
            $.ajax({
                url: '/Game/Shoot',
                data: { player: Player },
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    if (data.success) {
                        if (data.shootResult.isHit) {
                            $('#' + player + data.shootResult.positionV + data.shootResult.positionH).append('<i class=""fas fa-times""></i>');
                        }
                        else {
                            $('#' + player + data.shootResult.positionV + da");
                WriteLiteral(@"ta.shootResult.positionH).append('<i class=""fas fa-bomb""></i>');
                        }
                        isEnd = data.shootResult.isEnd;
                        isHit = data.shootResult.isHit;
                        gameLogic();
                    }
                    else {
                        console.log('Failed!');
                    }
                },
                error: function () {
                    console.log('Failed!');
                },
                complete: function () {
                }
            });
        }
        function displayShipsOnBoard(player, shipsArray) {
            for (var i = 0; i < shipsArray.length; i++) {
                var isHorizontal = shipsArray[i].isHorizontal;
                if (isHorizontal) {
                    var indexMinH = Math.min(...shipsArray[i].positions.map(position => position.horizontal));
                    var indexMaxH = Math.max(...shipsArray[i].positions.map(position => position.horizontal));
 ");
                WriteLiteral(@"               }
                else {
                    var indexMinV = Math.min(...shipsArray[i].positions.map(position => position.vertical));
                    var indexMaxV = Math.max(...shipsArray[i].positions.map(position => position.vertical));
                }


                for (var j = 0; j < shipsArray[i].positions.length; j++) {
                    var positionHorizontal = shipsArray[i].positions[j].horizontal;
                    var positionVertical = shipsArray[i].positions[j].vertical;

                    if (isHorizontal) {
                        switch (positionHorizontal) {
                            case indexMinH:
                                if (player === ""you"")
                                    $('#you' + positionVertical + positionHorizontal).append('<div class=""shipHorizontalLeft""></div>');
                                else
                                    $('#bot' + positionVertical + positionHorizontal).append('<div class=""shipHorizontalLeft");
                WriteLiteral(@" hideShip""></div>');
                                break;
                            case indexMaxH:
                                if (player === ""you"")
                                    $('#you' + positionVertical + positionHorizontal).append('<div class=""shipHorizontalRight""></div>');
                                else
                                    $('#bot' + positionVertical + positionHorizontal).append('<div class=""shipHorizontalRight hideShip""></div>');
                                break;
                            default:
                                if (player === ""you"")
                                    $('#you' + positionVertical + positionHorizontal).append('<div class=""shipHorizontalMid""></div>');
                                else
                                    $('#bot' + positionVertical + positionHorizontal).append('<div class=""shipHorizontalMid hideShip""></div>');
                        }
                    }
                    else {
         ");
                WriteLiteral(@"               switch (positionVertical) {
                            case indexMinV:
                                if (player === ""you"")
                                    $('#you' + positionVertical + positionHorizontal).append('<div class=""shipVerticalUp""></div>');
                                else
                                    $('#bot' + positionVertical + positionHorizontal).append('<div class=""shipVerticalUp hideShip""></div>');
                                break;
                            case indexMaxV:
                                if (player === ""you"")
                                    $('#you' + positionVertical + positionHorizontal).append('<div class=""shipVerticalDown""></div>');
                                else
                                    $('#bot' + positionVertical + positionHorizontal).append('<div class=""shipVerticalDown hideShip""></div>');
                                break;
                            default:
                                ");
                WriteLiteral(@"if (player === ""you"")
                                    $('#you' + positionVertical + positionHorizontal).append('<div class=""shipVerticalMid""></div>');
                                else
                                    $('#bot' + positionVertical + positionHorizontal).append('<div class=""shipVerticalMid hideShip""></div>');
                        }
                    }
                }

            }
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
