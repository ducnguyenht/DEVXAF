/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    ////Chỉ ra ngôn ngữ
    config.language = 'en';
    config.contentsCss = 'Content/StyleSheets/fonts.css';
    config.font_names = 'MyriadPro-Regular;' + config.font_names;
   // config.font_names = 'MyriadPro-SemiboldIt;MyriadPro-It;MyriadPro-Semibold;Arial/Arial;Helvetica;sans-serif;Times New Roman/Times New Roman;Times;serif;Verdana;';
    //config.enterMode = CKEDITOR.ENTER_BR;
    config.toolbar = 'Full';
    //Chỉ ra đường dẫn các loại tệp tin khi Finder
    //config.filebrowserBrowseUrl = '~/Content/ckfinder/ckfinder.html';
    //config.filebrowserImageBrowseUrl = '~/Content/ckfinder/ckfinder.html?type=Images';
    //config.filebrowserFlashBrowseUrl = '~/Content/ckfinder/ckfinder.html?type=Flash';
    //config.filebrowserUploadUrl = '~/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    //config.filebrowserImageUploadUrl = '~/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    //config.filebrowserFlashUploadUrl = '~/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
