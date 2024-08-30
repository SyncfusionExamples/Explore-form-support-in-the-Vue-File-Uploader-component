<template>
  <div class="form-support">
    <div class="control_wrapper">
      <form id="photoContestForm" action="https://localhost:44340/Home/Submit" method="POST" target="_blank"
        autocomplete="on">
        <h4 class="form-title">Photo Contest</h4>
        <div class="form-group">
          <div class="e-float-input">
            <input type="text" id="name" name="Name" data-required-message="* Enter your name" required
              data-msg-containerid="nameError" autocomplete="name">
            <span class="e-float-line"></span>
            <label class="e-float-text e-label-top" for="name">Name</label>
          </div>
          <div id="nameError"></div>
        </div>
        <div class="form-group">
          <div class="e-float-input">
            <input type="email" id="email" name="Email" data-validation="email"
              data-required-message="* Enter your email" required data-msg-containerid="mailError" autocomplete="email">
            <span class="e-float-line"></span>
            <label class="e-float-text e-label-top" for="email">Email</label>
          </div>
          <div id="mailError"></div>
        </div>
        <div class="form-group">
          <div class="e-float-input">
            <input type="text" id="mobileno" name="MobileNo" data-required-message="* Enter your mobile number" required
              data-msg-containerid="noError" autocomplete="tel">
            <span class="e-float-line"></span>
            <label class="e-float-text e-label-top" for="mobileno">Mobile No</label>
          </div>
          <div id="noError"></div>
        </div>
        <div class="form-group">
          <div class="e-float-input upload-area">
            <input type="text" id="fileNames" name="FileNames" data-required-message="* Select any image file" 
            required data-msg-containerid="uploadError">

            <ejs-uploader name="UploadFiles" :autoUpload="false"
            :allowedExtensions="'.png, .jpg'"
            :selected="onFileSelected"
            :dropArea="'.form-support'"
            ></ejs-uploader>

            <button id="browse-btn" type="button" class="e-control e-btn e-info">Browse...</button>
            
            <span class="e-float-line"></span>
            <label class="e-float-text e-label-top" for="fileNames">Choose image files</label>
          </div>
          <div id="uploadError"></div>
        </div>
        <div class="form-group">
          <div class="e-float-input">
            <textarea class="address-field" id="address" name="Address" autocomplete="street-address"></textarea>
            <span class="e-float-line"></span>
            <label class="e-float-text e-label-top" for="address">Address</label>
          </div>
        </div>
      </form>
      <div class="submitBtn">
        <button type="button" class="submit-btn e-btn" id="submit-btn">Submit</button>
      </div>
    </div>
  </div>
</template>

<script>
import { UploaderComponent } from '@syncfusion/ej2-vue-inputs';
import { FormValidator } from '@syncfusion/ej2-inputs';

export default {
  components: {
    "ejs-uploader": UploaderComponent
  },
  data() {
    return {
      path: {
        saveUrl: 'https://services.syncfusion.com/vue/production/api/FileUploader/Save',
        removeUrl: 'https://services.syncfusion.com/vue/production/api/FileUploader/Remove'
      },
      formObj: '',
      options: {
        customPlacement(inputElement, errorElement) {
          inputElement = inputElement.closest('.form-group').querySelector('.error');
          inputElement.parentElement.appendChild(errorElement);
        }
      }
    };
  },
  mounted() {
    document.getElementById('browse-btn').onclick = () =>{
      document.querySelector('.e-file-select-wrap button').click();
    }

    this.formObj = new FormValidator('#photoContestForm', this.options);

    document.getElementById('submit-btn').onclick = () => {
      if (this.formObj.validate()) {
        this.formObj.element.submit();
        this.formObj.element.reset();
      }
    };
  },
  methods:{
    onFileSelected(event){
      const fileNames = event.filesData.map(file => file.name).join(', ');
      document.getElementById('fileNames').value = fileNames;
    }
  }
};
</script>

<style>
@import "../node_modules/@syncfusion/ej2-base/styles/material.css";
@import "../node_modules/@syncfusion/ej2-buttons/styles/material.css";
@import "../node_modules/@syncfusion/ej2-vue-inputs/styles/material.css";

.form-support .control_wrapper {
  width: 500px;
  margin: auto;
  border: 1px solid #BEBEBE;
  box-shadow: 0 1px 3px 0 rgba(0, 0, 0, 0.36);
  padding: 1% 4% 2%;
  background: #f9f9f9;
}

.form-group {
  padding-top: 10px;
}

.form-support .form-title {
  text-align: center;
}

.form-support .address-field {
  max-height: 50px;
  resize: none;
}

.form-support .upload-area {
  width: 73%;
}

.form-support .e-error {
  padding-top: 3px;
}

.form-support form#photoContestForm {
  position: relative;
  top: 14%;
}

.form-support input.choose-file {
  width: 60%;
}

.form-support .submitBtn {
  position: relative;
  text-align: center;
  margin-top: 25px;
  margin-bottom: 15px;
}

.form-support button#browse-btn {
  float: right;
  margin-right: -115px;
  margin-top: -29px;
  position: relative;
}

.form-support .e-upload{
  display: none;
}
</style>
