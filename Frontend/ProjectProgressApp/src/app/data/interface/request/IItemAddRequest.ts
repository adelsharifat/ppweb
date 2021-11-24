export interface IItemAddRequest{
  name:String;
  parentId:string | null;
  itemType:any,
  userId:number;
}
