﻿using LeaveManager.Helpers;
using LeaveMgr.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LeaveManager.ExtendedHtmlHelpers
{
    public static class Controls
    {
        static ISessionSvc _sessionSvc;
        static Controls()
        {
            _sessionSvc = new SessionSvc();
        }

        private static object GetPropValue(object src, string propName)
        {
            object value = null;
            if (src.GetType().GetProperty(propName) != null)
            {
                value = src.GetType().GetProperty(propName).GetValue(src, null);
            }
            return value;
        }

        //Use the below code from cshtml view to get the submit button
        //@Html.LeaveMgrSubmitButton("submitButton", "my submit button label", new { onclick = "alert('abc');", @class = "btn btn-primary", id="myId" })
        public static MvcHtmlString LeaveMgrSubmitButton(this HtmlHelper helper, string name, string label, object htmlAttributes)
        {
            string controlText = helper.TextBox(name, label, htmlAttributes).ToString();
            controlText = controlText.Replace("type=\"text\"", "type=\"submit\"");
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        var editorField = new TagBuilder("span");
                        editorField.AddCssClass("disabledDiv");
                        editorField.InnerHtml += controlText;

                        return MvcHtmlString.Create(editorField.ToString());
                    }
                }
            }
            return MvcHtmlString.Create(controlText);
        }

        //Creates submit button with icon
        public static MvcHtmlString LeaveMgrSubmitButtonWithIcon(this HtmlHelper helper, string name, string label, object htmlAttributes,string iconClass, bool isImageAfterText=false)
        {
            string controlText = helper.TextBox(name, null, htmlAttributes).ToString();
            controlText = controlText.Replace("type=\"text\"", "type=\"submit\"");
            if(isImageAfterText)
            {
                controlText = controlText.Replace("<input", "<button").Replace("</input>", "").Replace("/>", "").Replace("value=\"\"", "") + "><span>" + label + "</span>&nbsp;&nbsp;&nbsp;<i class=\"" + iconClass + "\"></i>" + "</button>";
            }
            else
            {
                controlText = controlText.Replace("<input", "<button").Replace("</input>", "").Replace("/>", "").Replace("value=\"\"", "") + "><i class=\"" + iconClass + "\">&nbsp;&nbsp;&nbsp;</i><span>" + label + "</span>" + "</button>";
            }
            
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        var editorField = new TagBuilder("span");
                        editorField.AddCssClass("disabledDiv");
                        editorField.InnerHtml += controlText;

                        return MvcHtmlString.Create(editorField.ToString());
                    }
                }
            }
            return MvcHtmlString.Create(controlText);
        }

        //Creates normal button with icon
        public static MvcHtmlString LeaveMgrButtonWithIcon(this HtmlHelper helper, string name, string label, object htmlAttributes, string iconClass, bool isImageAfterText=false)
        {
            string controlText = helper.TextBox(name, null, htmlAttributes).ToString();
            controlText = controlText.Replace("type=\"text\"", "type=\"button\"");
            if (isImageAfterText)
            {
                controlText = controlText.Replace("<input", "<button").Replace("</input>", "").Replace("/>", "").Replace("value=\"\"", "") + "><span>" + label + "</span>&nbsp;&nbsp;&nbsp;<i class=\"" + iconClass + "\"></i>" + "</button>";
            }
            else
            {
                controlText = controlText.Replace("<input", "<button").Replace("</input>", "").Replace("/>", "").Replace("value=\"\"", "") + "><i class=\"" + iconClass + "\">&nbsp;&nbsp;&nbsp;</i><span>" + label + "</span>" + "</button>";
            }

            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        var editorField = new TagBuilder("span");
                        editorField.AddCssClass("disabledDiv");
                        editorField.InnerHtml += controlText;

                        return MvcHtmlString.Create(editorField.ToString());
                    }
                }
            }
            return MvcHtmlString.Create(controlText);
        }

        //Use the below code to add the normal button in cshtml view
        //@Html.LeaveMgrButton("submitButton", "my button label", new {onclick="alert('abc');", @class="btn btn-primary", id="myId1" })
        public static MvcHtmlString LeaveMgrButton(this HtmlHelper helper, string name, string label, object htmlAttributes)
        {
            string controlText = helper.TextBox(name, label, htmlAttributes).ToString();
            controlText = controlText.Replace("type=\"text\"", "type=\"button\"");
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        var editorField = new TagBuilder("span");
                        editorField.AddCssClass("disabledDiv");
                        editorField.InnerHtml += controlText;

                        return MvcHtmlString.Create(editorField.ToString());
                    }
                }
            }
            return MvcHtmlString.Create(controlText);
        }

        public static MvcHtmlString LeaveMgrDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string labelText, object htmlAttributes = null)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.DropDownListFor(expression, selectList, htmlAttributes).ToString(), true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.DropDownListFor(expression, selectList, htmlAttributes).ToString(), false, false);
        }

        public static MvcHtmlString LeaveMgrTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText, object htmlAttributes = null)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.TextBoxFor(expression, htmlAttributes).ToString(), true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.TextBoxFor(expression, htmlAttributes).ToString(), false, false);
        }

        public static MvcHtmlString LeaveMgrTextBoxForWithButton<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText, string btnClass, string btnId, string btnClickHandlerJS, object htmlAttributes = null)
        {
            string textBoxString = helper.TextBoxFor(expression, htmlAttributes).ToString();
            textBoxString = "<div class=\"input-group\"><span class=\"input-group-btn\"><button type=\"button\" class=\"btn btn-effect-ripple btn-primary\" id=\"" + btnId + "\" onclick=\"" + btnClickHandlerJS + "\"><i class=\"" + btnClass + "\"></i></button></span>" + textBoxString + "</div>";
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");                
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), textBoxString, true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), textBoxString, false, false);
        }

        public static MvcHtmlString LeaveMgrFileUpload<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText, object htmlAttributes = null)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.TextBoxFor(expression, htmlAttributes).ToString().Replace("type=\"text\"","type=\"file\""), true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.TextBoxFor(expression, htmlAttributes).ToString().Replace("type=\"text\"", "type=\"file\""), false, false);
        }

        //public static MvcHtmlString LeaveMgrActionLinkMultiple(this HtmlHelper htmlHelper, string linkText, string url,  object routeValues, object htmlAttributes)
        //{
        //    if(htmlAttributes!=null)
        //    {
        //        object objId = GetPropValue(htmlAttributes, "name");
        //        if (objId != null)
        //        {
        //            string id = objId.ToString();
        //            LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
        //            var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
        //            var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
        //            if (hiddenControl != null)
        //            {
        //                return new MvcHtmlString("");
        //            }
        //            if (disabledControl != null)
        //            {
        //                return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        //            }
        //        }
        //    }
        //    return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        //}

        public static MvcHtmlString LeaveMgrActionLinkMultiple(this HtmlHelper htmlHelper, string linkText, string url, object htmlAttributes)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "name");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                        if (!attributes.ContainsKey("disabled"))
                        {
                            attributes.Add("disabled", "disabled");
                        }
                        var tag = new TagBuilder("a");
                        if(attributes!=null)
                        {
                            tag.MergeAttributes(attributes);
                        }
                        tag.SetInnerText(linkText);
                        tag.MergeAttribute("href", url);
                        return MvcHtmlString.Create(tag.ToString());
                    }
                }
            }
            IDictionary<string, object> attributes1 = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var tag1 = new TagBuilder("a");
            if (attributes1 != null)
            {
                tag1.MergeAttributes(attributes1);
            }
            tag1.SetInnerText(linkText);
            tag1.MergeAttribute("href", url);
            return MvcHtmlString.Create(tag1.ToString());
        }

        public static MvcHtmlString LeaveMgrTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText, object htmlAttributes = null)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.TextAreaFor(expression, htmlAttributes).ToString(), true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.TextAreaFor(expression, htmlAttributes).ToString(), false, false);
        }

        public static MvcHtmlString LeaveMgrCheckBoxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, string labelText, object htmlAttributes = null)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.CheckBoxFor(expression, htmlAttributes).ToString(), true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.CheckBoxFor(expression, htmlAttributes).ToString(), false, false);
        }

        public static MvcHtmlString LeaveMgrRadioButtonfor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText, object htmlAttributes = null)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.RadioButtonFor(expression, htmlAttributes).ToString(), true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.RadioButtonFor(expression, htmlAttributes).ToString(), false, false);
        }

        private static MvcHtmlString FormLine(string labelContent, string fieldContent, bool isDisabled, bool isHidden, object htmlAttributes = null)
        {
            if(isHidden)
            {
                new MvcHtmlString("");
            }
            var editorLabel = new TagBuilder("label");
            //editorLabel.AddCssClass("editor-label");
            editorLabel.InnerHtml += labelContent;

            var editorField = new TagBuilder("div");
            //editorField.AddCssClass("editor-field");
            if(isDisabled)
            {
                editorField.AddCssClass("disabledDiv");
            }
            editorField.InnerHtml += fieldContent;

            var container = new TagBuilder("div");
            container.AddCssClass("form-group");
            //if (htmlAttributes != null)
                //container.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            //container.AddCssClass("form-line");
            container.InnerHtml += editorLabel;
            container.InnerHtml += editorField;

            return MvcHtmlString.Create(container.ToString());
        }

        public static MvcHtmlString LeaveMgrPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText, object htmlAttributes = null)
        {
            if (htmlAttributes != null)
            {
                object objId = GetPropValue(htmlAttributes, "id");
                if (objId != null)
                {
                    string id = objId.ToString();
                    LeaveMgr.Common.DTOs.SessionDTO session = _sessionSvc.GetUserSession();
                    var disabledControl = session.ActionList.FirstOrDefault(a => string.Equals(a.DisabledControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    var hiddenControl = session.ActionList.FirstOrDefault(a => string.Equals(a.HiddenControlId, id) && string.Equals(a.ParentAction.ActionLink, System.Web.HttpContext.Current.Request.Path));
                    if (hiddenControl != null)
                    {
                        return new MvcHtmlString("");
                    }
                    if (disabledControl != null)
                    {
                        return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.PasswordFor(expression, htmlAttributes).ToString(), true, false);
                    }
                }

            }
            return FormLine(helper.LabelFor(expression, labelText).ToString(), helper.PasswordFor(expression, htmlAttributes).ToString(), false, false);
        }

        //public static MvcHtmlString HelpTextFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string customText = null)
        //{
        //    // Can do all sorts of things here -- eg: reflect over attributes and add hints, etc...
        //} 
    }
}