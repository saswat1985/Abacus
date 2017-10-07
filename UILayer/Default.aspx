<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="full-width">
                <div class="clear">
                    <div class="clear">
                        <span class="lbl">Browse Excel File: </span>
                        <asp:FileUpload ID="btnFileUpload" runat="server" CssClass="button txtBox" />
                    </div>
                    <div class="clear">
                        <span class="lbl">Select Image Type:</span>
                        <asp:DropDownList ID="ddlImageType" runat="server" CssClass="dropdown">
                            <asp:ListItem Selected="True" Value="0">--Please Select--</asp:ListItem>
                            <asp:ListItem Value="1">Image Without Border</asp:ListItem>
                            <asp:ListItem Value="2">Image With Border</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="ddlImageType" ErrorMessage="Please Select Image Type" 
                            InitialValue="0" SetFocusOnError="True" ValidationGroup="upload"></asp:RequiredFieldValidator>
                    </div>
                    <div style="margin-top: 14px;">
                        <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload"
                            CssClass="button blue" ValidationGroup="upload" />
                        <asp:Button ID="btnTemplate" runat="server" Text="Click here to download sample excel file"
                            CssClass="button blue" OnClick="btnTemplate_Click" /></div>
                </div>
                <div style="margin-top: 14px; height: 650px; overflow-y: visible; overflow-x: hidden;" class="clear">
                    <asp:GridView ID="grdvConvertImageData" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" Width="940px" OnRowCommand="grdvConvertImageData_RowCommand"
                        OnRowDataBound="grdvConvertImageData_RowDataBound" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <FooterStyle Width="30px" />
                                <ItemStyle Height="16px" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Conversion Code" DataField="FileCode" />
                            <asp:BoundField HeaderText="Upload Date" DataField="UploadDate" />
                            <asp:BoundField HeaderText="Convertion Date" DataField="ConvertDate" />
                            <asp:BoundField HeaderText="ConvertBy" DataField="UserName" />
                            <asp:BoundField HeaderText="Upload File Name" DataField="ExcelFile" />
                            <asp:BoundField HeaderText="File Status" DataField="ConversionStatus" />
                             <asp:BoundField HeaderText="Process Image type" DataField="ImageType" />
                            <asp:TemplateField HeaderText="Download Rar File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ConvertFilepath") %>'
                                        CommandName="DownloadZip" Text="Download" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Download Uploaded Excel File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownloadExcel" runat="server" CausesValidation="False" CommandArgument='<%# Eval("UploadPath") %>'
                                        CommandName="DownloadExcel" Text="Download" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
