module Domain =
    type Address =
        { HouseNumber: int
          StreetName: string }
    
    type PhoneNumber = { Code: int; Number: string}

    type ContactMethod = 
    | PostalMail of Address
    | Email of string
    | VoiceMail of PhoneNumber

module Messenger =

    open Domain

    let sendMessage (message:string) (contactMethod: ContactMethod) =
        match contactMethod with
        // {HouseNumber=h; StreetName=s} - deconstruct Address record and access its values
        | PostalMail {HouseNumber=h; StreetName=s} -> printfn $"Mailing {message} to {h} {s}"
        | Email e -> printfn $"Emailing {message} to {e}"
        | VoiceMail {Code=c; Number=n} -> printfn $"Left +{c}{n} a voicemail saying {message}"

(*MAIN APP*)
open Domain
open Messenger

let message = "Can not talk now, learning F#!"

PostalMail {HouseNumber=123; StreetName="Elm street"}
|> sendMessage message

Email "abc@google.com"
|> sendMessage message

VoiceMail {Code=1; Number="123456"}
|> sendMessage message

