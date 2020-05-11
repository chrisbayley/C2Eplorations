# From Chris Bayley 20200501

# Must have Python installed.  Currently PPR using ActivePython 2.7
# For XP, in the 'Run' command line, type Python.  Hit Enter
# At the command prompt, paste the script below and press Enter.  May need to press Enter twice.

# Note: if no file found, a file will be returned with content similar to this: <p class="posStatusMessage">No closed trades.</p>


strategies = [115023400, 120622361, 119232154, 94987184]

date = datetime.date.today()
for strategy in strategies:
    print("Downloading strategy %d ......" % (strategy))
    url = 'https://collective2.com/strategy/csv/%d' % (strategy)
    urllib.urlretrieve(url, '~/Downloads/%d.%s.csv' % (strategy, date))
