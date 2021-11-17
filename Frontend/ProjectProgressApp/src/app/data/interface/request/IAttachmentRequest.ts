export interface IAttachment{
  fileName:String;
  fileStream:any;
  remark:String;
  createdBy:Number;
  itemId:Number;
}


export interface IAttachmentRequest{
  attachments:IAttachment[]
}

