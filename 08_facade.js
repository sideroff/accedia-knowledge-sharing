const http = require('http')

const server = http.createServer((request, response) => {
    response.write('OK')
    response.writeHead(200)
})

server.listen(port, (error) => {
    if(error) {
        console.error('Web server could not start, error: ', error)
        return
    }

    console.log(`Web server is listening on port ${port}`)
})