// replace these values with those generated in your TokBox Account
var apiKey = "46470112";
var sessionId = "2_MX40NjQ3MDExMn5-MTU3NTE3NzU0MTc3N35iR0Z4S0dEUjIvaDhOUGF3MmF6U0txNUp-fg";
var token = "T1==cGFydG5lcl9pZD00NjQ3MDExMiZzaWc9MzViYWViY2U5ZDAxMGU1YzM4YjQ1Yzc3YjJlZThhYWE1NzJhODA1MzpzZXNzaW9uX2lkPTJfTVg0ME5qUTNNREV4TW41LU1UVTNOVEUzTnpVME1UYzNOMzVpUjBaNFMwZEVVakl2YURoT1VHRjNNbUY2VTB0eE5VcC1mZyZjcmVhdGVfdGltZT0xNTc1MTc3NTY0Jm5vbmNlPTAuNDM2MjI5MDM5MDI1MjI3NDcmcm9sZT1wdWJsaXNoZXImZXhwaXJlX3RpbWU9MTU3NTE4MTE1NyZpbml0aWFsX2xheW91dF9jbGFzc19saXN0PQ==";

//// (optional) add server code here
//initializeSession();

// server code
//this creates a new token each time
//uses Ajax to make a request to the /session endpoint
var SERVER_BASE_URL = 'https://roommagnet.herokuapp.com';
fetch(SERVER_BASE_URL + '/session').then(function (res) {
    return res.json()
}).then(function (res) {
    apiKey = res.apiKey;
    sessionId = res.sessionId;
    token = res.token;
    initializeSession();
}).catch(handleError);



// Handling all of our errors here by alerting them
function handleError(error) {
    if (error) {
        alert(error.message);
    }
}

function initializeSession() {
    var session = OT.initSession(apiKey, sessionId);

    // Subscribe to a newly created stream
    session.on('streamCreated', function (event) {
        session.subscribe(event.stream, 'subscriber', {
            insertMode: 'append',
            width: '100%',
            height: '100%'
        }, handleError);
    });

    // Create a publisher
    var publisher = OT.initPublisher('publisher', {
        insertMode: 'append',
        width: '100%',
        height: '100%'
    }, handleError);

    // Connect to the session
    session.connect(token, function (error) {
        // If the connection is successful, publish to the session
        if (error) {
            handleError(error);
        } else {
            session.publish(publisher, handleError);
        }
    });
}

//Use the session ID in an OpenTok client library to connect to an OpenTok session.
//OpenTok opentok = new OpenTok(46470112, e93bf5dabccdc750e965266bd57fdede1e384157);
//string sessionId = opentok.CreateSession(Null, MediaMode.ROUTED).Id;