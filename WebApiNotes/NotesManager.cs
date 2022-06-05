using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNotes
{
    public class NotesManager
    {
        public List<NoteDTO> GetNotes()
        {
            var json = File.ReadAllText(@"..\\WebApiNotes\\\notes.json");
            List<NoteDTO> li = new List<NoteDTO>();
            try
            {
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray notes = (JArray)jObject["notes"];
                    if (notes != null)
                    {
                        foreach (var item in notes)
                        {
                            li.Add(new NoteDTO() { noteText=item["noteText"].ToString(),id=(int)item["id"]});
                        }

                    }
                   

                }
                return li;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddNote(NoteDTO dto)
        {


            var newobj = "{ 'id': " + dto.id + ",  'noteText': '" + dto.noteText + "'}";
            try
            {
                var json = File.ReadAllText(@"..\\WebApiNotes\\\notes.json");
                var jsonObj = JObject.Parse(json);
                var notes = jsonObj.GetValue("notes") as JArray;
                var newN = JObject.Parse(newobj);
                notes.Add(newN);

                jsonObj["notes"] = notes;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"..\\WebApiNotes\\\notes.json", newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }

        public void UpdateNote(NoteDTO dto)
        {       
            try
            {
                var json = File.ReadAllText(@"..\\WebApiNotes\\\notes.json");
                var jsonObj = JObject.Parse(json);
                var notes = jsonObj.GetValue("notes") as JArray;
                var note= notes.Where(i => i["id"].Value<int>() == dto.id).FirstOrDefault();
                note["noteText"] = dto.noteText;


                jsonObj["notes"] = notes;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"..\\WebApiNotes\\\notes.json", newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }

        public void DeleteNote(int id)
        {
            try
            {
                var json = File.ReadAllText(@"..\\WebApiNotes\\\notes.json");
                var jsonObj = JObject.Parse(json);
                var notes = jsonObj.GetValue("notes") as JArray;
                var note = notes.Where(i => i["id"].Value<int>() == id).FirstOrDefault();
                notes.Remove(note);


                jsonObj["notes"] = notes;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"..\\WebApiNotes\\\notes.json", newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }
    }
}
