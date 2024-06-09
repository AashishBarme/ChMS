declare var window: any;

export class DynamicEnvironment {
    public get environment() {
        return window.config.environment;
    }
    public get ApiUrl(){
      console.log(window)
      return window.config.ApiUrl;
    }
    public get MainUrl(){
      return window.config.MainUrl;
    }
    public get MediaUploadUrl(){
      return window.config.MediaUploadUrl;
    }

}
